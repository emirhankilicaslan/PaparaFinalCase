using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Concrete;

public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(PaparaDbContext context) : base(context)
    {
    }
}