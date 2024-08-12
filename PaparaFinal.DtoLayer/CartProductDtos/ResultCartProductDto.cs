using PaparaFinal.DtoLayer.CartDtos;
using PaparaFinal.DtoLayer.ProductDtos;

namespace PaparaFinal.DtoLayer.CartProductDtos;

public class ResultCartProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
}