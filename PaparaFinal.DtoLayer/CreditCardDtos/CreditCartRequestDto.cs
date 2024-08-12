namespace PaparaFinal.DtoLayer.CreditCardDtos;

public class CreditCartRequestDto
{
    public string CardNumber { get; set; }
    public double CardLimit { get; set; }
    public string Cvv { get; set; }
    public DateTime ExpireDate { get; set; }
}