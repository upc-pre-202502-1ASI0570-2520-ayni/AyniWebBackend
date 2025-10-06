using System.Text.Json.Serialization;
using AyniWebBackend.Ayni.Domain.Models;

namespace AyniWebBackend.Security.Domain.Models;

public class User
{
    public int Id  { get; set; }
    public string Username { get; set; }
    
    public string Role { get; set; }
    public string Email { get; set; }
    
    [JsonIgnore]
    public string PasswordHash { get; set; }
    public IList<Crop> Crops { get; set; } = new List<Crop>();
    public IList<Cost> Costs { get; set; } = new List<Cost>();
    public IList<Order> Orders { get; set; } = new List<Order>();
    public IList<Profit> Profits { get; set; } = new List<Profit>();
}