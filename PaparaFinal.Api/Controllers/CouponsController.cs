using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DtoLayer.CouponDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponsController : ControllerBase
{
    private readonly ICouponService _couponService;
    private readonly IMapper _mapper;

    public CouponsController(ICouponService couponService, IMapper mapper)
    {
        _couponService = couponService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = _couponService.GetAll();
        return Ok(list);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var entity = _couponService.GetById(id);
        return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoupon(CreateCouponDto couponDto)
    {
        var mapped = _mapper.Map<Coupon>(couponDto);
        _couponService.Add(mapped);
        return Ok("Kupon başarıyla eklendi !");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCoupon(UpdateCouponDto couponDto)
    {
        var mapped = _mapper.Map<Coupon>(couponDto);
        _couponService.Update(mapped);
        return Ok("Kupon başarıyla güncellendi !");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        var coupon = _couponService.GetById(id);
        _couponService.Delete(coupon);
        return Ok("Kupon başarıyla silindi !");
    }
}