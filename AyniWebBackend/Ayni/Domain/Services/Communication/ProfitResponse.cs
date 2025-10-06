using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Shared.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services.Communication;

public class ProfitResponse : BaseResponse<Profit>
{
    public ProfitResponse(string message) : base(message)
    {
    }
    public ProfitResponse(Profit resource) : base(resource)
    {
    }
}