namespace PaparaFinal.DtoLayer.OrderDtos;

public class ResultOrderDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public bool Status { get; set; }
    public int OrderNumber { get; set; }
    public int CartId { get; set; }
    public string? UserId { get; set; }
}