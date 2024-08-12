using FluentValidation;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Validations;

public class CategoryValidations : AbstractValidator<Category>
{
    public CategoryValidations()
    {
        RuleFor(x => x.Name)
            .NotEmpty().MaximumLength(20);
        
        RuleFor(x => x.Tag)
            .NotEmpty().MaximumLength(20);
        
        RuleFor(x => x.Url)
            .NotEmpty().MaximumLength(20);
        
        RuleFor(x => x.IsActive)
            .NotEmpty();
    }
}