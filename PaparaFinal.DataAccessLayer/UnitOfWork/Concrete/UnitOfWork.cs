using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Concrete;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;

namespace PaparaFinal.DataAccessLayer.UnitOfWork.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly PaparaDbContext _context;
    
    public ICategoryRepository CategoryRepository { get; private set; }
    public ICouponRepository CouponRepository { get; private set; }
    public IUserRepository UserRepository { get; private set; }
    public IProductRepository ProductRepository { get; private set; }
    public IOrderDetailRepository OrderDetailRepository { get; private set; }
    public IOrderRepository OrderRepository { get; private set; }
    public IDigitalWalletRepository DigitalWalletRepository { get; private set; }
    public ICartRepository CartRepository { get; private set; }
    public ICategoryProductRepository CategoryProductRepository { get; private set; }
    public ICartProductRepository CartProductRepository { get; private set; }

    public UnitOfWork(PaparaDbContext context)
    {
        _context = context;
        
        CategoryRepository = new CategoryRepository(_context);
        CouponRepository = new CouponRepository(_context);
        UserRepository = new UserRepository(_context);
        ProductRepository = new ProductRepository(_context);
        OrderDetailRepository = new OrderDetailRepository(_context);
        OrderRepository = new OrderRepository(_context);
        DigitalWalletRepository = new DigitalWalletRepository(_context);
        CartRepository = new CartRepository(_context);
        CategoryProductRepository = new CategoryProductRepository(_context);
        CartProductRepository = new CartProductRepository(_context);
    }
    
    public async Task Complete()
    {
        await _context.SaveChangesAsync();
    }

    public async Task CompleteWithTransaction()
    {
        using (var dbTransaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                await _context.SaveChangesAsync();
                await dbTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await dbTransaction.RollbackAsync();
                Console.WriteLine(ex);
                throw;
            }
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}