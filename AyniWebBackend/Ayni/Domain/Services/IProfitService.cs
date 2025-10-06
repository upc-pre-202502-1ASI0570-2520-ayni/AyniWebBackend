using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services;

public interface IProfitService
{
    Task<IEnumerable<Profit>> ListAsync();
    Task<IEnumerable<Profit>> ListByUserIdAsync(int userId);
    Task<ProfitResponse> SaveAsync(Profit profit);
    Task<ProfitResponse> UpdateAsync(int profitId, Profit 
        profit);
    Task<ProfitResponse> DeleteAsync(int profitId);
}