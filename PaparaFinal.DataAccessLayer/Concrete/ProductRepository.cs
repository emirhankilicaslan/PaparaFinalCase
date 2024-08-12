using Microsoft.EntityFrameworkCore;
using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Concrete;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly PaparaDbContext _context;
    public ProductRepository(PaparaDbContext context) : base(context)
    {
        _context = context;
    }

    public List<Product> ProductsOnSale()
    {
        return _context.Products.Where(x => x.IsActive == true || x.UnitsInStock > 0).ToList();
    }

    public void ChangeUnitsInStock(int stockQuantity, int productId)
    {
        var product = _context.Products.Where(x => x.Id == productId).FirstOrDefault();
        product.UnitsInStock = stockQuantity;
        if (product.UnitsInStock == 0)
        {
            product.IsActive = false;
        }
        if (product.UnitsInStock > 0)
        {
            product.IsActive = true;
        }
        _context.SaveChanges();
    }

        public List<Product> GetProductsByCategoryName(string categoryName)
        {
            return  _context.Products
                .Where(p => p.CategoryProducts.Any(cp => cp.Category.Name == categoryName))
                .ToList();
        }

        public void AddProductToCategory(int productId, int categoryId)
        {
            var category = _context.Categories.Include(c => c.CategoryProducts)
                .FirstOrDefault(c => c.Id == categoryId);
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            
            if (category != null || product != null)
            {
                category.CategoryProducts.Add(new CategoryProduct
                {
                    Product = product,
                    Category = category
                });
            }
            _context.SaveChanges();
        }

        public void AddProductToCart(int cartId, int productId, int quantity)
        {
            var cart = _context.Carts.Include(c => c.CartProducts)
                .FirstOrDefault(c => c.Id == cartId);
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (cart == null || product == null || product.UnitsInStock == 0)
            {
                throw new Exception("Islem gerceklestirilemiyor.");
            }
            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == productId);
            if (cartProduct != null)
            {
                cartProduct.Quantity += quantity;
                cart.CartAmount += product.Price * quantity;
                ChangeUnitsInStock(product.UnitsInStock - quantity, productId);
            }
            else
            {
                cart.CartProducts.Add(new CartProduct
                {
                    Cart = cart,
                    Product = product,
                    Quantity = quantity
                });
                ChangeUnitsInStock(product.UnitsInStock - quantity, productId);
                cart.CartAmount += product.Price * quantity;
            }
            _context.SaveChanges();
        }
}