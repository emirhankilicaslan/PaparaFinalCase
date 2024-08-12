using PaparaFinal.DtoLayer.CartProductDtos;
using PaparaFinal.DtoLayer.UserDtos;

namespace PaparaFinal.DtoLayer.CartDtos;

public class UpdateCartDto
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public double CartAmount { get; set; }
    
    public List<UpdateCartProductDto>? CartProducts { get; set; }
    public UpdateUserDto? User { get; set; }
}