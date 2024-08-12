using PaparaFinal.DtoLayer.CartDtos;
using PaparaFinal.DtoLayer.ProductDtos;

namespace PaparaFinal.DtoLayer.CartProductDtos;

public class UpdateCartProductDto
{
    public int CartProductId { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    
    public UpdateCartDto Cart { get; set; }
    public UpdateProductDto Product { get; set; }
}