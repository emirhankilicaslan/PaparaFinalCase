using Microsoft.AspNetCore.Identity;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Concrete;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }
    
    public void Delete (User entity)
    {
        _unitOfWork.UserRepository.Delete(entity);
        _unitOfWork.Complete();
    }

    public async Task<IdentityResult> Update(User entity)
    {
        var user = _unitOfWork.UserRepository.GetUserById(entity.Id);
        
        user.FirstName = entity.FirstName;
        user.LastName = entity.LastName;
        user.Email = entity.Email;
        user.UserName = entity.UserName;
        user.IdentityNumber = entity.IdentityNumber;
        
        _unitOfWork.UserRepository.Update(user);
        await _unitOfWork.Complete();
        
        return IdentityResult.Success;
    }
    public User GetById(string id)
    {
        return _unitOfWork.UserRepository.GetUserById(id);
    }
    
    public string GetUserIdByUserName(string userName)
    {
        return _unitOfWork.UserRepository.GetUserIdByUserName(userName);
    }
    public List<User> GetAll()
    {
       return _unitOfWork.UserRepository.GetAll();
    }

    public void UpdateWalletBalance(string id, double balance)
    {
        _unitOfWork.UserRepository.UpdateWalletBalance(id, balance);
    }
}