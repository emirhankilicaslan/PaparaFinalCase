namespace PaparaFinal.EntityLayer.Entities;

public class OrderDetail
{
    public int Id { get; set; }
    public double TotalPrice { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    public virtual List<CartProduct> CartProducts { get; set; }
}