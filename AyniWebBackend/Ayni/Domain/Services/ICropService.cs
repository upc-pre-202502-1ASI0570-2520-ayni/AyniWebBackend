using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services;

public interface ICropService
{
    Task<IEnumerable<Crop>> ListAsync();
    Task<IEnumerable<Crop>> ListByUserIdAsync(int userId);
    Task<CropResponse> SaveAsync(Crop crop);
    Task<CropResponse> UpdateAsync(int cropId, Crop 
        crop);
    Task<CropResponse> DeleteAsync(int cropId);
}