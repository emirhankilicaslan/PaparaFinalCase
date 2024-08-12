namespace PaparaFinal.DtoLayer.CouponDtos;

public class UpdateCouponDto
{
    public int Id { get; set; }
    public string CouponCode { get; set; }
    public double DiscountAmount { get; set; }
    public bool IsActive { get; set; }
    public DateTime ExpireDate { get; set; }
}