using PaparaFinal.DataAccessLayer.Abstract;

namespace PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;

public interface IUnitOfWork : IDisposable
{
    Task Complete();
    Task CompleteWithTransaction();
    ICategoryRepository CategoryRepository { get; }
    ICouponRepository CouponRepository { get; }
    IUserRepository UserRepository { get; }
    IProductRepository ProductRepository { get; }
    IOrderDetailRepository OrderDetailRepository { get; }
    IOrderRepository OrderRepository { get; }
    IDigitalWalletRepository DigitalWalletRepository { get; }
    ICartRepository CartRepository { get; }
    ICategoryProductRepository CategoryProductRepository { get; }
    ICartProductRepository CartProductRepository { get; }
}