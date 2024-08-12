using System.Linq.Expressions;
using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Concrete;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly PaparaDbContext _context;
    public OrderRepository(PaparaDbContext context) : base(context)
    {
        _context = context;
    }
    public List<Order> GetActiveOrders()
    {
        return _context.Orders.Where(x => x.Status == true).ToList();
    }
    public List<Order> GetPastOrders()
    {
        return _context.Orders.Where(x => x.Status == false).ToList();
    }

    public void ChangeOrderStatusToFalse(int orderId)
    {
        var order = _context.Orders.Where(x => x.Id == orderId).FirstOrDefault();
        if (order is null)
        {
            throw new Exception("Siparis bulunamadi.");
        }
        order.Status = false;
    }
}