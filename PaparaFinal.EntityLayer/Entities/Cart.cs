namespace PaparaFinal.EntityLayer.Entities;

public class Cart
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public virtual User? User { get; set; }
    public double CartAmount { get; set; }
    public virtual List<CartProduct>? CartProducts { get; set; }
    
}