using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;
using PaparaFinal.DtoLayer.CartProductDtos;
using PaparaFinal.DtoLayer.CreditCardDtos;
using PaparaFinal.DtoLayer.PaymentDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Concrete;

public class CartService : ICartService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICreditCardService _creditCardService;
    private readonly ICouponService _couponService;
    /*private readonly IOrderService _orderService;
    private readonly IUserService _userService;*/
    

    public CartService(IUnitOfWork unitOfWork, ICreditCardService creditCardService, ICouponService couponService/*, IOrderService orderService, IUserService userService*/)
    {
        _unitOfWork = unitOfWork;
        _creditCardService = creditCardService;
        _couponService = couponService;
        /*_orderService = orderService;
        _userService = userService;*/
    }
    public void Add(Cart entity)
    {
        var cart = new Cart
        {
            CartAmount = entity.CartAmount,
            UserId = entity.UserId,
        };
        _unitOfWork.CartRepository.Add(cart);
        _unitOfWork.Complete();
    }

    public void Delete(Cart entity)
    {
        _unitOfWork.CartRepository.Delete(entity);
        _unitOfWork.Complete();
    }

    public void Update(Cart entity)
    {
        _unitOfWork.CartRepository.Update(entity);
        _unitOfWork.Complete();
    }   

    public Cart GetById(int id)
    {
        return _unitOfWork.CartRepository.GetById(id);
    }

    public List<Cart> GetAll()
    {
        return _unitOfWork.CartRepository.GetAll();
    }
    
    public List<ResultCartProductDto> GetProductsFromCart(int cartId)
    {
        return _unitOfWork.CartRepository.GetProductsFromCart(cartId);
    }

    public bool PayTheCart(string? couponCode, int cartId, string userId, CreditCartRequestDto creditCardDto)
    {
        var cart = _unitOfWork.CartRepository.GetById(cartId);
        if (cart == null) throw new Exception("Cart not found.");
        Coupon coupon = _couponService.GetCouponByCode(couponCode);
        
        var productInCart = _unitOfWork.CartRepository.GetProductsFromCart(cartId);
        var cartAmount = _unitOfWork.CartRepository.GetCartPaymentInfo(couponCode, cartId).cartAmount;
        var walletDiscount = _unitOfWork.CartRepository.GetCartPaymentInfo(couponCode, cartId).walletDiscount;
        var couponDiscount = _unitOfWork.CartRepository.GetCartPaymentInfo(couponCode, cartId).couponDiscount;
        var earnedPoints = _unitOfWork.CartRepository.EarnedPointsFromPurchase(productInCart);

        var totalDiscount = couponDiscount + walletDiscount;
        if (cartAmount > totalDiscount)
        {
            var finalAmount = cartAmount - totalDiscount;
            var paymentResult = _creditCardService.PayWithCreditCard(finalAmount, creditCardDto);
            if (paymentResult)
            {
                _unitOfWork.UserRepository.UpdateWalletBalance(userId, earnedPoints);
                _unitOfWork.CartRepository.ClearCart(cart);
                if (coupon is not null)
                {
                    coupon.IsActive = false;
                }
                cart.CartAmount = 0;
                _unitOfWork.Complete();
                return true;
            }

            return false;
        }
        else
        {
            var finalAmount = totalDiscount - cartAmount;
            _unitOfWork.UserRepository.UpdateWalletBalance(userId, finalAmount);
            coupon.IsActive = false;
            _unitOfWork.CartRepository.ClearCart(cart);
            _unitOfWork.Complete();
            return true;
        }
    }
}