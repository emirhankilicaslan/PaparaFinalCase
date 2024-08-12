using PaparaFinal.DtoLayer.CreditCardDtos;

namespace PaparaFinal.BusinessLayer.Abstract;

public interface ICreditCardService
{
    bool PayWithCreditCard(double amount, CreditCartRequestDto creditCardDto);
}