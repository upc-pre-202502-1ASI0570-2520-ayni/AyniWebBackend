using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Shared.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services.Communication;

public class CostResponse : BaseResponse<Cost>
{
    public CostResponse(string message) : base(message)
    {
    }
    public CostResponse(Cost resource) : base(resource)
    {
    }
}