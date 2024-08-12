namespace PaparaFinal.DtoLayer.CouponDtos;

public class CreateCouponDto
{
    public string CouponCode { get; set; }
    public double DiscountAmount { get; set; }
    public bool IsActive { get; set; }
    public DateTime ExpireDate { get; set; }
    public string? UserId { get; set; }
}