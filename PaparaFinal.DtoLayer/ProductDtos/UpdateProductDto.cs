namespace PaparaFinal.DtoLayer.ProductDtos;

public class UpdateProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int UnitsInStock { get; set; }
    public bool IsActive { get; set; }
    public const double DefaultPointsEarningPercentage = 0.1;
    public const double DefaultMaxPoints = 150; // Maximum amount of points to be earned
}