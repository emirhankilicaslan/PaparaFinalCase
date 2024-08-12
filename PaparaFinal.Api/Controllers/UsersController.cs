using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DtoLayer.UserDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = _mapper.Map<List<ResultUserDto>>( _userService.GetAll());
        return Ok(list);
    }
    [HttpGet("{id}")]
    public IActionResult GetUserById(string id)
    {
        var user = _mapper.Map<ResultUserDto>(_userService.GetById(id));
        return Ok(user);
    }
    
    [HttpGet("GetUserByUserName")]
    public IActionResult GetUserByUserName(string userName)
    {
        string id = _userService.GetUserIdByUserName(userName);
        var user = _mapper.Map<ResultUserDto>(_userService.GetById(id));
        return Ok(user);
    }

    [HttpPut]
    [Authorize(Policy = "OnlyAdminUsers")]
    public IActionResult UpdateUser(UpdateUserDto userDto)
    {
        var mapped = _mapper.Map<User>(userDto);
        _userService.Update(mapped);
        return Ok("Kullanıcı başarıyla güncellendi !");
    }
    
    [HttpDelete]
    [Authorize(Policy = "OnlyAdminUsers")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = _userService.GetById(id);
        _userService.Delete(user);
        return Ok("Kullanıcı başarıyla silindi !");
    }
}