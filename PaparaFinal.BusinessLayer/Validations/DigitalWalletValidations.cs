using FluentValidation;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Validations;

public class DigitalWalletValidations : AbstractValidator<DigitalWallet>
{
    public DigitalWalletValidations()
    {
        RuleFor(x => x.Balance)
            .NotEmpty();
    }
}