using FluentValidation;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Validations;

public class OrderDetailValidations : AbstractValidator<OrderDetail>
{
    public OrderDetailValidations()
    {
        RuleFor(x => x.TotalPrice)
            .NotEmpty().GreaterThan(0);
    }
}