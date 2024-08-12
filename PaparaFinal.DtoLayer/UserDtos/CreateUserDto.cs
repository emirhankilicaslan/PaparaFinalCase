namespace PaparaFinal.DtoLayer.UserDtos;

public class CreateUserDto
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long IdentityNumber { get; set; }
}