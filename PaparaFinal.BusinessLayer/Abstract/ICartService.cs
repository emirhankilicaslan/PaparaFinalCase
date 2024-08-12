using PaparaFinal.DtoLayer.CartProductDtos;
using PaparaFinal.DtoLayer.CreditCardDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Abstract;

public interface ICartService : IGenericService<Cart>
{
    public bool PayTheCart(string? couponCode, int cartId, string userId, CreditCartRequestDto creditCardDto);
    List<ResultCartProductDto> GetProductsFromCart(int cartId);
}