namespace AyniWebBackend.Ayni.Resources;

public class SaveProductResource
{
    public string Name { get; set; }
    public string Description { get; set; }

    public int UnitPrice { get; set; }

    public int Quantity { get; set; }
    
    public string ImageUrl { get; set; }
}