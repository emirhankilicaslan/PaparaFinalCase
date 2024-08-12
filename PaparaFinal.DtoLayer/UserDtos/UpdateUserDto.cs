namespace PaparaFinal.DtoLayer.UserDtos;

public class UpdateUserDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long IdentityNumber { get; set; }
}