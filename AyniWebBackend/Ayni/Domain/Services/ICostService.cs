using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services;

public interface ICostService
{
    Task<IEnumerable<Cost>> ListAsync();
    Task<IEnumerable<Cost>> ListByUserIdAsync(int userId);
    Task<CostResponse> SaveAsync(Cost cost);
    Task<CostResponse> UpdateAsync(int costId, Cost 
        cost);
    Task<CostResponse> DeleteAsync(int costId);
}