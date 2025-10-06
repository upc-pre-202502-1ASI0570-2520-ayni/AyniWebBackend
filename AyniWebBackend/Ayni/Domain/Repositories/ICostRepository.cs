using AyniWebBackend.Ayni.Domain.Models;

namespace AyniWebBackend.Ayni.Domain.Repositories;

public interface ICostRepository
{
    Task<IEnumerable<Cost>> ListAsync();
    Task AddAsync(Cost cost);
    Task<Cost> FindByIdAsync(int costId);
    Task<Cost> FindByTitleAsync(string name); //importante name
    Task<IEnumerable<Cost>> FindByUserIdAsync(int userId);
    void Update(Cost cost);
    void Remove(Cost cost);
}