using AutoMapper;
using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Services;
using AyniWebBackend.Ayni.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AyniWebBackend.Ayni.Controllers;

[ApiController]
[Route("/api/v1/users/{userId}/orders")]
public class UserOrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    
    private readonly IMapper _mapper;
    
    public UserOrdersController(IMapper mapper, IOrderService orderService)
    {
        
        _mapper = mapper;
        _orderService = orderService;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Orders for given User",
        Description = "Get existing Orders associated with the specified User",
        OperationId = "GetUserOrders",
        Tags = new[] { "UserOrders"}
    )]
    public async Task<IEnumerable<OrderResource>> GetAllByUserIdAsync(int userId)
    {
        var orders = await _orderService.ListByUserIdAsync(userId);

        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);

        return resources;
    }
    
    
    
}