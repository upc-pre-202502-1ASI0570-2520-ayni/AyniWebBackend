using AyniWebBackend.Security.Domain.Models;

namespace AyniWebBackend.Ayni.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string OrderedDate { get; set; }
    public int TotalPrice { get; set; }
    public string PaymentMethod { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
    

}