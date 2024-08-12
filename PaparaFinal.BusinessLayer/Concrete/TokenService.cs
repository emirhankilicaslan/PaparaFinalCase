using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Concrete;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IConfigurationSection _jwtSettings;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        _jwtSettings = _configuration.GetSection("JwtSettings");
    }

    public async Task<string> CreateToken(User user, IList<string> roles)
    {
        var signInCredentials = GetSigningCredentials();
        var claims = GetClaims(user, roles);
        var claimList = await claims;
        var tokenOptions = await GenerateTokenOptions(signInCredentials, claimList);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtSettings["Secret"]);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims(User user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
        };
        
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        return claims;
    }

    private async Task<JwtSecurityToken> GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claim)
    {
        var tokenOptions = new JwtSecurityToken(
            issuer:_jwtSettings["Issuer"],
            audience: _jwtSettings["Audience"],
            claims: claim,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["AccessTokenExpiration"])),
            signingCredentials: signingCredentials
            );
        return tokenOptions;
    }
}