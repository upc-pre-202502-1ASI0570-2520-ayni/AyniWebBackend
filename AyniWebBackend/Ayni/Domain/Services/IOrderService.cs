using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> ListAsync();
    Task<IEnumerable<Order>> ListByUserIdAsync(int userId);

    Task<OrderResponse> SaveAsync(Order order);
    Task<OrderResponse> UpdateAsync(int orderId, Order 
        order);
    Task<OrderResponse> DeleteAsync(int orderId);
}