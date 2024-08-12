using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PaparaFinal.DtoLayer.RegisterDtos;
using PaparaFinal.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using PaparaFinal.DtoLayer.UserDtos;

namespace PaparaFinal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public RegisterController(UserManager<User> userManager, IMapper mapper)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    
    [HttpPost("RegisterAdminUser")]
    [Authorize(Policy = "OnlyAdminUsers")]
    public async Task<IActionResult> RegisterAdmin([FromBody] CreateUserDto userDto)
    {
        var newUser = new User
        {
            UserName = userDto.UserName,
            Email = userDto.Email,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            EmailConfirmed = true,
            TwoFactorEnabled = false,
            IdentityNumber = userDto.IdentityNumber.ToString(),
        };

        var result = await _userManager.CreateAsync(newUser, userDto.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description);
            return BadRequest(new RegistrationResponseDto() { Errors = errors });
        }
        
        await _userManager.AddToRoleAsync(newUser, "Admin");
        return StatusCode(201, "Kullanıcı oluşturuldu.");
    }

    [HttpPost("RegisterNormalUser")]
    public async Task<IActionResult> RegisterCustomer([FromBody] CreateUserDto userDto)
    {
        /*var mapped = _mapper.Map<User>(userDto);
        _userService.Add(mapped);
        return Ok("Kullanıcı başarıyla eklendi !");*/
        var newUser = new User
        {
            UserName = userDto.UserName,
            Email = userDto.Email,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            EmailConfirmed = true,
            TwoFactorEnabled = false,
            IdentityNumber = userDto.IdentityNumber.ToString(),
        };

        var result = await _userManager.CreateAsync(newUser, userDto.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description);
            return BadRequest(new RegistrationResponseDto() { Errors = errors });
        }
        
        
        await _userManager.AddToRoleAsync(newUser, "User");
        return StatusCode(201, "Kullanıcı oluşturuldu.");
    }
}