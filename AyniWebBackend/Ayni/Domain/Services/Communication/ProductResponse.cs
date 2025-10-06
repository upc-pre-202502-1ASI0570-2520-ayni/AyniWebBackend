using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Shared.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services.Communication;

public class ProductResponse : BaseResponse<Product>
{
    public ProductResponse(string message) : base(message)
    {
    }
    public ProductResponse(Product resource) : base(resource)
    {
    }
    
}