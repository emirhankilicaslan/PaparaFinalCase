using Microsoft.AspNetCore.Identity;

namespace PaparaFinal.EntityLayer.Entities;

public class Role : IdentityRole
{
    public string Description { get; set; }
}