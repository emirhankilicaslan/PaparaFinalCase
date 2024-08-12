using PaparaFinal.DtoLayer.CartProductDtos;
using PaparaFinal.DtoLayer.OrderDtos;

namespace PaparaFinal.DtoLayer.OrderDetailDtos;

public class ResultOrderDetailDto
{
    public int Id { get; set; }
    public double TotalPrice { get; set; }
    public int OrderId { get; set; }
    public ResultOrderDto Order { get; set; }
    public List<ResultCartProductDto> CartProducts { get; set; }
}