using PaparaFinal.DtoLayer.CartProductDtos;
using PaparaFinal.DtoLayer.PaymentDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Abstract;

public interface ICartRepository : IGenericRepository<Cart>
{
    List<ResultCartProductDto> GetProductsFromCart(int cartId);
    PaymentResponseDto GetCartPaymentInfo(string? couponCode, int cartId);
    double EarnedPointsFromPurchase(List<ResultCartProductDto> cartProducts);
    void ClearCart(Cart cart);
}