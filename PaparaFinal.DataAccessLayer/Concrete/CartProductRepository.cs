using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Concrete;

public class CartProductRepository : GenericRepository<CartProduct>, ICartProductRepository
{
    public CartProductRepository(PaparaDbContext context) : base(context)
    {
    }
}