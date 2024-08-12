using PaparaFinal.DtoLayer.UserDtos;

namespace PaparaFinal.DtoLayer.OrderDtos;

public class CreateOrderDto
{
    public DateTime OrderDate { get; set; }
    public bool Status { get; set; } // Active - Passive order
    public int CartId { get; set; }
    public string? UserId { get; set; }
    public CreateUserDto? User { get; set; }
}