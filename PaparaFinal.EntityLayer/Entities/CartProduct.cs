namespace PaparaFinal.EntityLayer.Entities;

public class CartProduct
{
    public int CartProductId { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    
    public virtual Cart Cart { get; set; }
    public virtual Product Product { get; set; }
}