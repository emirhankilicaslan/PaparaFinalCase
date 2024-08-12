using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Abstract;

public interface IOrderRepository : IGenericRepository<Order>
{
    List<Order> GetPastOrders();
    List<Order> GetActiveOrders();
    void ChangeOrderStatusToFalse(int orderId);
}