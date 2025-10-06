using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Shared.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services.Communication;

public class OrderResponse : BaseResponse<Order>
{
    public OrderResponse(string message) : base(message)
    {
    }
    public OrderResponse(Order resource) : base(resource)
    {
    }
}