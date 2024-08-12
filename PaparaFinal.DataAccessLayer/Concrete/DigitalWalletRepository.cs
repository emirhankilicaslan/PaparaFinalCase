using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Concrete;

public class DigitalWalletRepository : GenericRepository<DigitalWallet>, IDigitalWalletRepository
{
    public DigitalWalletRepository(PaparaDbContext context) : base(context)
    {
    }
}