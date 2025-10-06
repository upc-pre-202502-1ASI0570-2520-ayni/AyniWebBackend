using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Shared.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services.Communication;

public class CropResponse : BaseResponse<Crop>
{
    public CropResponse(string message) : base(message)
    {
    }
    public CropResponse(Crop resource) : base(resource)
    {
    }

}