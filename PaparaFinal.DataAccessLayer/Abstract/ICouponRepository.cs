using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Abstract;

public interface ICouponRepository : IGenericRepository<Coupon>
{
    Coupon GetCouponByCode(string couponCode);
}