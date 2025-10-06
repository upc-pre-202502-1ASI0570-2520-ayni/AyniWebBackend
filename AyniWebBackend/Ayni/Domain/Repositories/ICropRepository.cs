using AyniWebBackend.Ayni.Domain.Models;

namespace AyniWebBackend.Ayni.Domain.Repositories;

public interface ICropRepository
{
    Task<IEnumerable<Crop>> ListAsync();
    Task AddAsync(Crop crop);
    Task<Crop> FindByIdAsync(int cropId);
    Task<Crop> FindByTitleAsync(string name);
    Task<IEnumerable<Crop>> FindByUserIdAsync(int userId);
    void Update(Crop crop);
    void Remove(Crop crop);

}