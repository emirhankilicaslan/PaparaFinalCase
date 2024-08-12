namespace PaparaFinal.DtoLayer.OrderDtos;

public class UpdateOrderDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public bool Status { get; set; } // Active - Passive order
    public int OrderNumber { get; set; }
    public int CartId { get; set; }
    public string? UserId { get; set; }
}