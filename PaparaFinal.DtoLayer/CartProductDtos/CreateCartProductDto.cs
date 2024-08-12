using PaparaFinal.DtoLayer.CartDtos;
using PaparaFinal.DtoLayer.ProductDtos;

namespace PaparaFinal.DtoLayer.CartProductDtos;

public class CreateCartProductDto
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    
    public CreateCartDto Cart { get; set; }
    public CreateProductDto Product { get; set; }
}