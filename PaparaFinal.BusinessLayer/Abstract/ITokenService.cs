using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Abstract;

public interface ITokenService
{ 
    Task<string> CreateToken(User user, IList<string> roles);
}