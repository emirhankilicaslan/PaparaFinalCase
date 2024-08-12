namespace PaparaFinal.EntityLayer.Entities;

public class Coupon
{
    public int Id { get; set; }
    public string CouponCode { get; set; }
    public double DiscountAmount { get; set; }
    public bool IsActive { get; set; }
    public DateTime ExpireDate { get; set; }

    public string? UserId { get; set; }
    public virtual User? User { get; set; }
}