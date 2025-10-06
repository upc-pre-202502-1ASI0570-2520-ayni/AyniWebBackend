using AutoMapper;
using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Services;
using AyniWebBackend.Ayni.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AyniWebBackend.Ayni.Controllers;

[ApiController]
[Route("/api/v1/users/{userId}/costs")]
public class UserCostsController : ControllerBase
{
    private readonly ICostService _costService;
    private readonly IMapper _mapper;

    public UserCostsController(ICostService costService, IMapper mapper)
    {
        _costService = costService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Costs for given User",
        Description = "Get existing Cost associated with the specified User",
        OperationId = "GetUserCosts",
        Tags = new[] { "UserCosts"}
    )]
    public async Task<IEnumerable<CostResource>> GetAllByUserIdAsync(int userId)
    {
        var costs = await _costService.ListByUserIdAsync(userId);

        var resources = _mapper.Map<IEnumerable<Cost>, IEnumerable<CostResource>>(costs);

        return resources;
    }
    
    
}