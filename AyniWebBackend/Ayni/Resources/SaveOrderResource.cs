namespace AyniWebBackend.Ayni.Resources;

public class SaveOrderResource
{
    public string Description { get; set; }
    public string Status { get; set; }
    public string OrderedDate { get; set; }
    public int TotalPrice { get; set; }
    public string PaymentMethod { get; set; }
    
    public int ProductId { get; set; }
    public int UserId { get; set; }
}