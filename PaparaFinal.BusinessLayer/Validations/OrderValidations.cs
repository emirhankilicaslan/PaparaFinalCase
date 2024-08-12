using System.Data;
using FluentValidation;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Validations;

public class OrderValidations : AbstractValidator<Order>
{
    public OrderValidations()
    {
        RuleFor(x => x.OrderNumber)
            .NotEmpty().InclusiveBetween(9,9);

        RuleFor(x => x.OrderDate)
            .NotEmpty().LessThan(DateTime.Now);
        
        RuleFor(x => x.Status)
            .NotEmpty();
        
        RuleFor(x => x.OrderDetail)
            .NotEmpty();
    }
}