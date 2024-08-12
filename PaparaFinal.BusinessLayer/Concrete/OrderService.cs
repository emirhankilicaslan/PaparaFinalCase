using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Concrete;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderDetailService _orderDetailService;

    public OrderService(IUnitOfWork unitOfWork, IOrderDetailService orderDetailService)
    {
        _unitOfWork = unitOfWork;
        _orderDetailService = orderDetailService;
    }
    
    public void Add(Order entity)
    {
        var order = new Order()
        {
            OrderDate = entity.OrderDate,
            OrderNumber = new Random().Next(1000000, 9999999),
            Status = entity.Status,
            CartId = entity.CartId,
            UserId = entity.UserId
        };
        _unitOfWork.OrderRepository.Add(order);
        _unitOfWork.Complete();
    }

    public void Delete(Order entity)
    {
        _unitOfWork.OrderRepository.Delete(entity);
        _unitOfWork.Complete();
    }

    public void Update(Order entity)
    {
        _unitOfWork.OrderRepository.Update(entity);
        _unitOfWork.Complete();
    }   

    public Order GetById(int id)
    {
        return _unitOfWork.OrderRepository.GetById(id);
    }

    public List<Order> GetAll()
    {
        return _unitOfWork.OrderRepository.GetAll();
    }

    public List<Order> GetPastOrders()
    {
        return _unitOfWork.OrderRepository.GetPastOrders();
    }

    public List<Order> GetActiveOrders()
    {
        return _unitOfWork.OrderRepository.GetActiveOrders();
    }

    public void ChangeOrderStatusToFalse(int orderId)
    {
        _unitOfWork.OrderRepository.ChangeOrderStatusToFalse(orderId);
        _unitOfWork.Complete();
    }
}