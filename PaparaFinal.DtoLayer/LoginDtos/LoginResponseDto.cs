namespace PaparaFinal.DtoLayer.RegisterDtos;

public class LoginResponseDto
{
    public bool IsSuccessful { get; set; }
    public string? AccessToken { get; set; }
    public string? Error { get; set; }
}