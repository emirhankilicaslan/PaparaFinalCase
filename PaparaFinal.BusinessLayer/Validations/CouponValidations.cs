using System.Data;
using FluentValidation;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Validations;

public class CouponValidations : AbstractValidator<Coupon>
{
    public CouponValidations()
    {
        RuleFor(x => x.DiscountAmount)
            .NotEmpty().GreaterThan(0);
        
        RuleFor(x => x.CouponCode)
            .NotEmpty().Length(10);
        
        RuleFor(x => x.ExpireDate)
            .NotEmpty().LessThan(DateTime.Now);
        
        RuleFor(x => x.IsActive)
            .NotEmpty();
    }
}