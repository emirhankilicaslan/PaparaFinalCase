using PaparaFinal.DtoLayer.CartProductDtos;
using PaparaFinal.DtoLayer.OrderDtos;

namespace PaparaFinal.DtoLayer.OrderDetailDtos;

public class UpdateOrderDetailDto
{
    public int Id { get; set; }
    public double TotalPrice { get; set; }
    public int OrderId { get; set; }
    public UpdateOrderDto Order { get; set; }
    public List<UpdateCartProductDto> CartProducts { get; set; }
}