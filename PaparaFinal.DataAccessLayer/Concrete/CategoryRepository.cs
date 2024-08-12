using Microsoft.EntityFrameworkCore;
using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Concrete;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly PaparaDbContext _context;
    public CategoryRepository(PaparaDbContext context) : base(context)
    {
        _context = context;
    }

    public List<Category> GetActiveCategoryList()
    {
        return _context.Categories.Where(x => x.IsActive == true).ToList();
    }

    public void AddCategoryToProduct(int productId, int categoryId)
    {
        var product = _context.Products.Include(c => c.CategoryProducts)
            .FirstOrDefault(c => c.Id == productId);
        var category = _context.Categories.Find(categoryId);
            
        if (category != null && product != null)
        {
            product.CategoryProducts.Add(new CategoryProduct
            {
                Product = product,
                Category = category
            });
        }
    }
}