using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Concrete;

public class CouponService : ICouponService
{
    private readonly IUnitOfWork _unitOfWork;

    public CouponService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Add(Coupon entity)
    {
        var coupon = new Coupon()
        {
            UserId = entity.UserId,
            DiscountAmount = entity.DiscountAmount,
            CouponCode = entity.CouponCode,
            ExpireDate = entity.ExpireDate,
            IsActive = entity.IsActive
        };
        _unitOfWork.CouponRepository.Add(coupon);
        _unitOfWork.Complete();
    }

    public void Delete(Coupon entity)
    {
        _unitOfWork.CouponRepository.Delete(entity);
        _unitOfWork.Complete();
    }

    public void Update(Coupon entity)
    {
        _unitOfWork.CouponRepository.Update(entity);
        _unitOfWork.Complete();
    }

    public Coupon GetById(int id)
    {
        return _unitOfWork.CouponRepository.GetById(id);
    }

    public List<Coupon> GetAll()
    {
        return _unitOfWork.CouponRepository.GetAll();
    }

    public Coupon GetCouponByCode(string couponCode)
    {
        return _unitOfWork.CouponRepository.GetCouponByCode(couponCode);
    }
}