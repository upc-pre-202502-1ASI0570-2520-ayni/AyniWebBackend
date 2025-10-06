using AyniWebBackend.Ayni.Domain.Models;

namespace AyniWebBackend.Ayni.Domain.Repositories;

public interface IProfitRepository
{
    Task<IEnumerable<Profit>> ListAsync();
    Task AddAsync(Profit profit);
    Task<Profit> FindByIdAsync(int profitId);
    Task<Profit> FindByTitleAsync(string name); //importante name
    Task<IEnumerable<Profit>> FindByUserIdAsync(int userId);
    void Update(Profit profit);
    void Remove(Profit profit);
}