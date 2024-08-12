using FluentValidation;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Validations;

public class ProductValidations : AbstractValidator<Product>
{
    public ProductValidations()
    {
        RuleFor(x =>x.Name)
            .NotEmpty()
            .MaximumLength(30)
            .WithMessage("Name must be maximum 30 characters !");
        
        RuleFor(x =>x.Description)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Description must be maximum 50 characters !");
        
        RuleFor(x => x.Price)
            .NotEmpty().GreaterThan(0);
        
        RuleFor(x => x.UnitsInStock)
            .NotEmpty().GreaterThan(0);
        
        RuleFor(x => x.IsActive)
            .NotEmpty();
    }
}