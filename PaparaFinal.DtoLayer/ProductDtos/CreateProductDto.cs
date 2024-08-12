namespace PaparaFinal.DtoLayer.ProductDtos;

public class CreateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int UnitsInStock { get; set; }
    public bool IsActive { get; set; }
    public const double DefaultPointsEarningPercentage = 0.1;
    public const double DefaultMaxPoints = 150;
}
