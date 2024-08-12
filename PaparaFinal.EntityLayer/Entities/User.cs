using Microsoft.AspNetCore.Identity;

namespace PaparaFinal.EntityLayer.Entities;

public class User : IdentityUser
{
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual DigitalWallet? DigitalWallet { get; set; }
    public virtual Cart? Cart { get; set; }
    public virtual List<Coupon>? Coupons { get; set; }
}