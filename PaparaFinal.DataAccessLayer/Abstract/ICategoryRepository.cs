using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Abstract;

public interface ICategoryRepository : IGenericRepository<Category>
{
     List<Category> GetActiveCategoryList();
     void AddCategoryToProduct(int productId, int categoryId);
}