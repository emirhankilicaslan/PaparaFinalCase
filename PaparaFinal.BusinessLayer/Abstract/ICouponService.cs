using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Abstract;

public interface ICouponService : IGenericService<Coupon>
{
    Coupon GetCouponByCode(string couponCode);
}