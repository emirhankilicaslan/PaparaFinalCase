using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DtoLayer.CreditCardDtos;

namespace PaparaFinal.BusinessLayer.Concrete;

public class CreditCardService : ICreditCardService
{
    public bool PayWithCreditCard(double amount, CreditCartRequestDto creditCardDto)
    {
        var cardNumberLength = creditCardDto.CardNumber.Length;
        var cvvLength = creditCardDto.Cvv.Length;
        var expireDate = creditCardDto.ExpireDate;
        var limit = creditCardDto.CardLimit;
        
        if (cardNumberLength == 16 && cvvLength == 3 && expireDate > DateTime.Now && limit > amount)
        {
            return true;
        }
        return false;
    }
}