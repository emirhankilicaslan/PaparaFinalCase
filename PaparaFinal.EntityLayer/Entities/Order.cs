namespace PaparaFinal.EntityLayer.Entities;

public class Order
{
    public int Id { get; set; }
    
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public bool Status { get; set; } // Active Order: true  - Past Order: false
    public string? UserId { get; set; }
    public virtual User User { get; set; }
    public int CartId { get; set; }
    public virtual Cart Cart { get; set; }
    public virtual OrderDetail OrderDetail { get; set; }
}