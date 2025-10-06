using AyniWebBackend.Security.Domain.Models;

namespace AyniWebBackend.Ayni.Domain.Models;

public class Crop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string Distance { get; set; }

    public string Depth { get; set; }

    public string Weather { get; set; }

    public string GroundType { get; set; }

    public string Season { get; set; }
    
    public string ImageUrl { get; set; }


    public int UserId { get; set; }
    public User User { get; set; }
}