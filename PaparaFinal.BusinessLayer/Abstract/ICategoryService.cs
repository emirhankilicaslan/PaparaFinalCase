using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Abstract;

public interface ICategoryService : IGenericService<Category>
{
    List<Category> GetActiveCategoryList();
    void AddCategoryToProduct(int productId, int categoryId);
}