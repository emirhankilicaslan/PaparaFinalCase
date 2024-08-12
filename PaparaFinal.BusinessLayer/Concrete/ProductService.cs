using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Concrete;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(Product entity)
    {
        var product = new Product()
        {
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            UnitsInStock = entity.UnitsInStock,
            IsActive = entity.IsActive,
            CategoryProducts = entity.CategoryProducts
        };
        _unitOfWork.ProductRepository.Add(product);
        _unitOfWork.Complete();
    }

    public void Delete(Product entity)
    {
        _unitOfWork.ProductRepository.Delete(entity);
        _unitOfWork.Complete();
    }

    public void Update(Product entity)
    {
        _unitOfWork.ProductRepository.Update(entity);
        _unitOfWork.Complete();
    }   

    public Product GetById(int id)
    {
        return _unitOfWork.ProductRepository.GetById(id);
    }

    public List<Product> GetAll()
    {
        return _unitOfWork.ProductRepository.GetAll();
    }

    public List<Product> GetProductsOnSale()
    {
        return _unitOfWork.ProductRepository.ProductsOnSale();
    }

    public void ChangeUnitsInStock(int stockQuantity, int productId)
    {
        _unitOfWork.ProductRepository.ChangeUnitsInStock(stockQuantity, productId);
        _unitOfWork.Complete();
    }

    public List<Product> GetProductsByCategoryName(string categoryName)
    {
        return _unitOfWork.ProductRepository.GetProductsByCategoryName(categoryName);
    }

    public void AddProductToCategory(int productId, int categoryId)
    {
        _unitOfWork.ProductRepository.AddProductToCategory(productId, categoryId);
        _unitOfWork.Complete();
    }

    public void AddProductToCart(int cartId, int productId, int quantity)
    {
        _unitOfWork.ProductRepository.AddProductToCart(cartId, productId, quantity);
        _unitOfWork.Complete();
    }
}