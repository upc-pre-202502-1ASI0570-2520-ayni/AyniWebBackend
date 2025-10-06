using AyniWebBackend.Security.Domain.Models;

namespace AyniWebBackend.Ayni.Domain.Models;

public class Cost
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
}