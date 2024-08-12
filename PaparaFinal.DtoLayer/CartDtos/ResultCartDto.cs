using PaparaFinal.DtoLayer.ProductDtos;

namespace PaparaFinal.DtoLayer.CartDtos;

public class ResultCartDto
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public double CartAmount { get; set; }
    public List<ResultProductDto> Products { get; set; }
}