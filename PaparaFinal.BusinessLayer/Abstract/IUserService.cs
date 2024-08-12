using Microsoft.AspNetCore.Identity;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Abstract;

public interface IUserService
{
    public string GetUserIdByUserName(string userName);
    public User GetById(string id);
    List<User> GetAll();
    void Delete(User entity);
    Task<IdentityResult> Update(User entity);
    void UpdateWalletBalance(string id, double balance);
}