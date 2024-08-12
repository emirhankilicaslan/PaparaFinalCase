using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DtoLayer.RegisterDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<User> _userManager;
    
    public LoginController(UserManager<User> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
    {
        var user = await _userManager.FindByEmailAsync(requestDto.Email!);
        if (user is null || !await _userManager.CheckPasswordAsync(user, requestDto.Password!))
            return Unauthorized(new LoginResponseDto { IsSuccessful = false, Error = "Invalid authentication." });
        var roles = _userManager.GetRolesAsync(user);
        var roleList = await roles;
        var token = await _tokenService.CreateToken(user, roleList);
        return Ok(new LoginResponseDto { IsSuccessful = true, AccessToken = token });
    }
}