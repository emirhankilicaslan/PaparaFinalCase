using Microsoft.EntityFrameworkCore;
using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.DtoLayer.CartProductDtos;
using PaparaFinal.DtoLayer.PaymentDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Concrete;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    private readonly PaparaDbContext _context;
    
    public CartRepository(PaparaDbContext context) : base(context)
    {
        _context = context;
    }

    public PaymentResponseDto GetCartPaymentInfo(string? couponCode, int cartId)
    {
        double couponDiscount = 0;
        if (couponCode is not null)
        {
            couponDiscount = _context.Carts
                .Include(x => x.User)
                .ThenInclude(y => y.Coupons)
                .SelectMany(c => c.User.Coupons)
                .Where(a => a.CouponCode == couponCode)
                .Select(z => z.DiscountAmount).FirstOrDefault();
        }

        var walletDiscount = _context.Carts
            .Include(x => x.User)
            .ThenInclude(y => y.DigitalWallet)
            .Select(c => c.User.DigitalWallet)
            .Select(z => z.Balance).SingleOrDefault();

        var cartAmount = _context.Carts.Where(x=>x.Id == cartId).Select(x => x.CartAmount).SingleOrDefault();
        return new PaymentResponseDto
            { walletDiscount = walletDiscount, couponDiscount = couponDiscount, cartAmount = cartAmount };
    }

    public List<ResultCartProductDto> GetProductsFromCart(int cartId)
    {
        var cart = _context.Carts
            .Include(c => c.CartProducts)
            .ThenInclude(cp => cp.Product)
            .FirstOrDefault(c => c.Id == cartId);
        
        if (cart is null)
        {
            return new List<ResultCartProductDto>();
        }

        var products = cart.CartProducts
            .Select(cp => new ResultCartProductDto
            {
                ProductId = cp.Product.Id,
                Name = cp.Product.Name,
                Price = cp.Product.Price * cp.Quantity,
                Quantity = cp.Quantity,
                Description = cp.Product.Description
            })
            .ToList();
        return products;
    }
    
    public double EarnedPointsFromPurchase(List<ResultCartProductDto> cartProducts)
    {
        double pointsEarned = 0;
        foreach (var cartProduct in cartProducts)
        {
            double amountSpent =+ cartProduct.Price * cartProduct.Quantity;
            var earned = Math.Min(amountSpent * Product.DefaultPointsEarningPercentage * cartProduct.Quantity, Product.DefaultMaxPoints * cartProduct.Quantity);
            pointsEarned = pointsEarned + earned;
        }
        return pointsEarned;
    }

    public void ClearCart(Cart cart)
    {
        cart.CartProducts.Clear();
        _context.SaveChanges();
    }
}