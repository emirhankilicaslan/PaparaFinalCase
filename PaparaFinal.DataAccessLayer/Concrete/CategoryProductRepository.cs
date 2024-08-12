using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Concrete;

public class CategoryProductRepository : GenericRepository<CategoryProduct>, ICategoryProductRepository
{
    public CategoryProductRepository(PaparaDbContext context) : base(context)
    {
    }
}