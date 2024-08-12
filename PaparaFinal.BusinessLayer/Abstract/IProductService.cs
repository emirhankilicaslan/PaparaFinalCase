using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Abstract;

public interface IProductService : IGenericService<Product>
{
    List<Product> GetProductsOnSale();
    void ChangeUnitsInStock(int stockQuantity, int productId);
    List<Product> GetProductsByCategoryName(string categoryName);
    void AddProductToCategory(int productId, int categoryId);
    public void AddProductToCart(int cartId, int productId, int quantity);
}