using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<ProductResponse> SaveAsync(Product product);
    Task<ProductResponse> UpdateAsync(int productId, Product 
        product);
    Task<ProductResponse> DeleteAsync(int productId);
}