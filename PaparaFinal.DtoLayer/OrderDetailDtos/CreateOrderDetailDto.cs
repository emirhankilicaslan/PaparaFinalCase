using PaparaFinal.DtoLayer.CartProductDtos;
using PaparaFinal.DtoLayer.OrderDtos;

namespace PaparaFinal.DtoLayer.OrderDetailDtos;

public class CreateOrderDetailDto
{
    public double TotalPrice { get; set; }
    public int OrderId { get; set; }
    public CreateOrderDto Order { get; set; }
    public List<CreateCartProductDto> CartProducts { get; set; }
}