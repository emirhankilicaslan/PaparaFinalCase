using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Concrete;

public class CartProductService : ICartProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public CartProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(CartProduct entity)
    {
        var cartProduct = new CartProduct()
        {
            Cart = entity.Cart,
            CartId = entity.CartId,
            Product = entity.Product,
            ProductId = entity.ProductId
        };
        _unitOfWork.CartProductRepository.Add(cartProduct);
        _unitOfWork.Complete();
    }

    public void Delete(CartProduct entity)
    {
        _unitOfWork.CartProductRepository.Delete(entity);
        _unitOfWork.Complete();
    }

    public void Update(CartProduct entity)
    {
        _unitOfWork.CartProductRepository.Update(entity);
        _unitOfWork.Complete();
    }   

    public CartProduct GetById(int id)
    {
        return _unitOfWork.CartProductRepository.GetById(id);
    }

    public List<CartProduct> GetAll()
    {
        return _unitOfWork.CartProductRepository.GetAll();
    }
}