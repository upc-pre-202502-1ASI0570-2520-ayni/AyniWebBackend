using AyniWebBackend.Ayni.Domain.Models;

namespace AyniWebBackend.Ayni.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
    Task AddAsync(Product product);
    Task<Product> FindByIdAsync(int productId);
    void Update(Product product);
    void Remove(Product product);
}