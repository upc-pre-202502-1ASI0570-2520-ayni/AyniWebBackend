namespace AyniWebBackend.Ayni.Resources;

public class SaveCropResource
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Distance { get; set; }

    public string Depth { get; set; }

    public string Weather { get; set; }

    public string GroundType { get; set; }

    public string Season { get; set; }
    
    public string ImageUrl { get; set; }
    
    public int UserId { get; set; }
}