using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Concrete;

public class CouponRepository : GenericRepository<Coupon>, ICouponRepository
{
    private readonly PaparaDbContext _context;
    public CouponRepository(PaparaDbContext context) : base(context)
    {
        _context = context;
    }

    public Coupon GetCouponByCode(string couponCode)
    {
        return _context.Coupons.Where(x => x.CouponCode == couponCode).SingleOrDefault();
    }
}