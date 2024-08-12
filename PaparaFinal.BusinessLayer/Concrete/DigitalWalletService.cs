using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DataAccessLayer.UnitOfWork.Abstract;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Concrete;

public class DigitalWalletService : IDigitalWalletService
{
    private readonly IUnitOfWork _unitOfWork;

    public DigitalWalletService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void Add(DigitalWallet entity)
    {
        var wallet = new DigitalWallet()
        {
            Balance = entity.Balance,
            UserId = entity.UserId
        };
        _unitOfWork.DigitalWalletRepository.Add(entity);
        _unitOfWork.Complete();
    }

    public void Delete(DigitalWallet entity)
    {
        _unitOfWork.DigitalWalletRepository.Delete(entity);
        _unitOfWork.Complete();
    }

    public void Update(DigitalWallet entity)
    {
        _unitOfWork.DigitalWalletRepository.Update(entity);
        _unitOfWork.Complete();
    }   

    public DigitalWallet GetById(int id)
    {
        return _unitOfWork.DigitalWalletRepository.GetById(id);
    }

    public List<DigitalWallet> GetAll()
    {
        return _unitOfWork.DigitalWalletRepository.GetAll();
    }
}