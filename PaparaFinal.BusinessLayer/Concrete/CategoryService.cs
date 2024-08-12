using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Concrete;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void Add(Category entity)
    {
        var category = new Category
        {
            Name = entity.Name,
            Tag = entity.Tag,
            Url = entity.Url,
            IsActive = entity.IsActive
        };
        _unitOfWork.CategoryRepository.Add(category);
        _unitOfWork.Complete();
    }

    public void Delete(Category entity)
    {
        _unitOfWork.CategoryRepository.Delete(entity);
        _unitOfWork.Complete();
    }

    public void Update(Category entity)
    {
        _unitOfWork.CategoryRepository.Update(entity);
        _unitOfWork.Complete();
    }   

    public Category GetById(int id)
    {
        return _unitOfWork.CategoryRepository.GetById(id);
    }

    public List<Category> GetAll()
    {
        return _unitOfWork.CategoryRepository.GetAll();
    }

    public List<Category> GetActiveCategoryList()
    {
        return _unitOfWork.CategoryRepository.GetActiveCategoryList();
    }

    public void AddCategoryToProduct(int productId, int categoryId)
    {
        _unitOfWork.CategoryRepository.AddCategoryToProduct(productId, categoryId);
        _unitOfWork.Complete();
    }
}