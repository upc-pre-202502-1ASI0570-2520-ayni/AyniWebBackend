using AyniWebBackend.Security.Domain.Models;

namespace AyniWebBackend.Ayni.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int UnitPrice { get; set; }

    public int Quantity { get; set; }
    
    public string ImageUrl { get; set; }
    
    public IList<Order> Orders { get; set; } = new List<Order>();
    public IList<User> Users { get; set; } = new List<User>();

}