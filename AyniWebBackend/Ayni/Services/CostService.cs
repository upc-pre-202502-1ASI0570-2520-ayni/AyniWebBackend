using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Repositories;
using AyniWebBackend.Ayni.Domain.Services;
using AyniWebBackend.Ayni.Domain.Services.Communication;
using AyniWebBackend.Security.Domain.Repositories;

namespace AyniWebBackend.Ayni.Services;

public class CostService : ICostService
{
    private readonly ICostRepository _costRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public CostService(ICostRepository costRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _costRepository = costRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Cost>> ListAsync()
    {
        return await _costRepository.ListAsync();
    }

    public async Task<IEnumerable<Cost>> ListByUserIdAsync(int userId)
    {
        return await _costRepository.FindByUserIdAsync(userId);
    }

    public async Task<CostResponse> SaveAsync(Cost cost)
    {
        // Validate UserId
        var existingUser = await 
            _userRepository.FindByIdAsync(cost.UserId);
        if (existingUser == null)
            return new CostResponse("Invalid User");
 
        // Validate Title
        var existingCostWithTitle = await 
            _costRepository.FindByTitleAsync(cost.Name);
        if (existingCostWithTitle != null)
            return new CostResponse("Crop name already exists.");
        try
        {
            // Add Tutorial
            await _costRepository.AddAsync(cost);
 
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
 
            // Return response
            return new CostResponse(cost);
        }
        catch (Exception e)
        {
            // Error Handling
            return new CostResponse($"An error occurred when saving the costs: {e.Message}");
        }
    }

    public async Task<CostResponse> UpdateAsync(int costId, Cost cost)
    {
        var existingCost = await 
            _costRepository.FindByIdAsync(costId);
 
        // Validate Tutorial
        if (existingCost == null)
            return new CostResponse("Cost not found.");
 
        // Modify Fields
        existingCost.Name = cost.Name;
        existingCost.Description = cost.Description;
        existingCost.Amount = cost.Amount;
        //existingCost.UserId = cost.UserId;
        try
        {
            _costRepository.Update(existingCost);
            await _unitOfWork.CompleteAsync();
            return new CostResponse(existingCost);
 
        }
        catch (Exception e)
        {
            // Error Handling
            return new CostResponse($"An error occurred when updating the cost: {e.Message}");
        }
    }

    public async Task<CostResponse> DeleteAsync(int costId)
    {
        var existingCost = await 
            _costRepository.FindByIdAsync(costId);
 
        // Validate Tutorial
        if (existingCost == null)
            return new CostResponse("Cost not found.");
 
        try
        {
            _costRepository.Remove(existingCost);
            await _unitOfWork.CompleteAsync();
            return new CostResponse(existingCost);
 
        }
        catch (Exception e)
        {
            // Error Handling
            return new CostResponse($"An error occurred when deleting the cost: {e.Message}");
        }
    }
}