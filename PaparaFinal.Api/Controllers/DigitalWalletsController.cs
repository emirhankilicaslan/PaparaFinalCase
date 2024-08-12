using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DtoLayer.DigitalWalletDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DigitalWalletsController : ControllerBase
{
    private readonly IDigitalWalletService _digitalWalletService;
    private readonly IMapper _mapper;

    public DigitalWalletsController(IDigitalWalletService digitalWalletService, IMapper mapper)
    {
        _digitalWalletService = digitalWalletService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = _digitalWalletService.GetAll();
        return Ok(list);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var entity = _digitalWalletService.GetById(id);
        return Ok(entity);
    }

    [HttpPost]
    public  IActionResult CreateDigitalWallet(CreateDigitalWalletDto digitalWalletDto)
    {
        var mapped = _mapper.Map<DigitalWallet>(digitalWalletDto);
        _digitalWalletService.Add(mapped);
        return Ok("Dijital cüzdan başarıyla eklendi !");
    }

    [HttpPut]
    public IActionResult UpdateDigitalWallet(UpdateDigitalWalletDto digitalWalletDto)
    {
        var mapped = _mapper.Map<DigitalWallet>(digitalWalletDto);
        _digitalWalletService.Update(mapped);
        return Ok("Dijital cüzdan başarıyla güncellendi !");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteDigitalWallet(int id)
    {
        var digitalWallet = _digitalWalletService.GetById(id);
        _digitalWalletService.Delete(digitalWallet);
        return Ok("Dijital cüzdan başarıyla silindi !");
    }
}