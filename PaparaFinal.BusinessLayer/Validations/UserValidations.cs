using FluentValidation;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Validations;

public class UserValidations : AbstractValidator<User>
{
    public UserValidations()
    {
        RuleFor(x =>x.IdentityNumber)
            .NotEmpty()
            .Length(11)
            .WithMessage("Identity number must be 11 characters !");
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .Length(3, 30)
            .WithMessage("First name length must be between 3-20 characters !");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .Length(2, 20)
            .WithMessage("Last name length must be between 2-20 characters !");
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .Length(3, 20)
            .WithMessage("First name length must be between 3-20 characters !");

        RuleFor(x => x.UserName)
            .NotEmpty()
            .Length(2, 20)
            .WithMessage("User name length must be between 2-20 characters !");
        RuleFor(x => x.Email)
            .NotEmpty()
            .Length(2, 25)
            .WithMessage("User name length must be between 2-25 characters !");
    }
}