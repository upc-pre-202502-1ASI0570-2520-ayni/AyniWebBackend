using AutoMapper;
using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Services;
using AyniWebBackend.Ayni.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AyniWebBackend.Ayni.Controllers;

[ApiController]
[Route("/api/v1/users/{userId}/profits")]
public class UserProfitsController : ControllerBase
{
    private readonly IProfitService _profitService;
    private readonly IMapper _mapper;
    
    public UserProfitsController(IProfitService profitService, IMapper mapper)
    {
        _profitService = profitService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Profits for given User",
        Description = "Get existing Profit associated with the specified User",
        OperationId = "GetUserProfits",
        Tags = new[] { "UserProfits"}
    )]
    public async Task<IEnumerable<ProfitResource>> GetAllByUserIdAsync(int userId)
    {
        var profits = await _profitService.ListByUserIdAsync(userId);

        var resources = _mapper.Map<IEnumerable<Profit>, IEnumerable<ProfitResource>>(profits);

        return resources;
    }
    
}