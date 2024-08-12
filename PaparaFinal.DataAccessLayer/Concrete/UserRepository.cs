using Microsoft.EntityFrameworkCore;
using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Concrete;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly PaparaDbContext _context;
    public UserRepository(PaparaDbContext context) : base(context)
    {
        _context = context;
    }

    public string GetUserIdByUserName(string userName)
    {
        return _context.Users.Where(x => x.UserName == userName).Select(z => z.Id).FirstOrDefault();
    }

    public User GetUserById(string id)
    {
        return _context.Users.Where(x => x.Id == id).FirstOrDefault();
    }

    public void UpdateWalletBalance(string id, double balance)
    {
        var user = _context.Users.Where(x => x.Id == id).Include(y=> y.DigitalWallet).FirstOrDefault();
        if (user is null)
        {
            throw new Exception("User not found.");
        }
        user.DigitalWallet.Balance = balance;
    }
}