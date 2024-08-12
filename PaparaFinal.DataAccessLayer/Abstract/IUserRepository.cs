using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Abstract;

public interface IUserRepository : IGenericRepository<User>
{
    string GetUserIdByUserName(string userName);
    User GetUserById(string id);
    void UpdateWalletBalance(string id, double balance);
}