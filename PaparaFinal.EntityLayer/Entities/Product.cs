namespace PaparaFinal.EntityLayer.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int UnitsInStock { get; set; }
    public bool IsActive { get; set; }
    public const double DefaultPointsEarningPercentage = 0.1;
    public const double DefaultMaxPoints = 150; // Maximum amount of points to be earned
    public virtual List<CategoryProduct> CategoryProducts { get; set; }
    public virtual List<CartProduct> CartProducts { get; set; } 
}