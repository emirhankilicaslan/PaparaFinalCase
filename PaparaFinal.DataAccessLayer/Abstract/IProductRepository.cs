using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Abstract;

public interface IProductRepository : IGenericRepository<Product>
{
    List<Product> ProductsOnSale();
    void ChangeUnitsInStock(int stockQuantity, int productId);
    List<Product> GetProductsByCategoryName(string categoryName);
    void AddProductToCategory(int productId, int categoryId);
    public void AddProductToCart(int cartId, int productId, int quantity);
}