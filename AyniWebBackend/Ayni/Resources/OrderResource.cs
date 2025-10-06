using AyniWebBackend.Security.Resources;

namespace AyniWebBackend.Ayni.Resources;

public class OrderResource
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string OrderedDate { get; set; }
    public int TotalPrice { get; set; }
    public string PaymentMethod { get; set; }
    
    public UserResource User { get; set; }
    public ProductResource Product { get; set; }
}