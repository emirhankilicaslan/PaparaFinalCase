using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Abstract;

public interface IOrderService : IGenericService<Order>
{
    List<Order> GetPastOrders();
    List<Order> GetActiveOrders();
    void ChangeOrderStatusToFalse(int orderId);
}