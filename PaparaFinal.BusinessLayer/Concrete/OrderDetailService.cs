using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Concrete;

public class OrderDetailService : IOrderDetailService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderDetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(OrderDetail entity)
    {
        var orderDetail = new OrderDetail()
        {
            OrderId = entity.Order.Id,
            Order = entity.Order,
            TotalPrice = entity.TotalPrice
        };
        _unitOfWork.OrderDetailRepository.Add(orderDetail);
        _unitOfWork.Complete();
    }

    public void Delete(OrderDetail entity)
    {
        _unitOfWork.OrderDetailRepository.Delete(entity);
        _unitOfWork.Complete();
    }

    public void Update(OrderDetail entity)
    {
        _unitOfWork.OrderDetailRepository.Update(entity);
        _unitOfWork.Complete();
    }

    public OrderDetail GetById(int id)
    {
        return _unitOfWork.OrderDetailRepository.GetById(id);
    }

    public List<OrderDetail> GetAll()
    {
        return _unitOfWork.OrderDetailRepository.GetAll();
    }
}