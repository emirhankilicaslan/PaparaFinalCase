using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Concrete;

public class CategoryProductService : ICategoryProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(CategoryProduct entity)
    {
        var categoryProduct = new CategoryProduct()
        {
            Category = entity.Category,
            CategoryId = entity.CategoryId,
            Product = entity.Product,
            ProductId = entity.ProductId
        };
        _unitOfWork.CategoryProductRepository.Add(categoryProduct);
        _unitOfWork.Complete();
    }

    public void Delete(CategoryProduct entity)
    {
        _unitOfWork.CategoryProductRepository.Delete(entity);
        _unitOfWork.Complete();
    }

    public void Update(CategoryProduct entity)
    {
        _unitOfWork.CategoryProductRepository.Update(entity);
        _unitOfWork.Complete();
    }   

    public CategoryProduct GetById(int id)
    {
        return _unitOfWork.CategoryProductRepository.GetById(id);
    }

    public List<CategoryProduct> GetAll()
    {
        return _unitOfWork.CategoryProductRepository.GetAll();
    }
}