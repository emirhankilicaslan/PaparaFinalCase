using FluentValidation;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Validations;

public class CartValidations : AbstractValidator<Cart>
{
    public CartValidations()
    {
        RuleFor(x => x.CartAmount)
            .NotEmpty();
    }
}