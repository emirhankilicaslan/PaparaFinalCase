using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;
using PaparaFinal.DtoLayer.CartDtos;
using PaparaFinal.DtoLayer.CartProductDtos;
using PaparaFinal.DtoLayer.CreditCardDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly ICartService _cartService;
    private readonly IMapper _mapper;
    private readonly IOrderService _orderService;

    public CartsController(ICartService cartService, IMapper mapper, IOrderService orderService)
    {
        _cartService = cartService;
        _mapper = mapper;
        _orderService = orderService;
    }
    
    [HttpGet]
    [Authorize(Policy = "OnlyAdminUsers")]
    public async Task<IActionResult> GetAll()
    {
        var mapped = _mapper.Map<List<ResultCartDto>>(_cartService.GetAll());
        return Ok(mapped);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var entity = _cartService.GetById(id);
        return Ok(entity);
    }

    [HttpPost]
    [Authorize(Policy = "OnlyAdminUsers")]
    public  IActionResult CreateCart(CreateCartDto cartDto)
    {
        var mapped = _mapper.Map<Cart>(cartDto);
        _cartService.Add(mapped);
        return Ok("Sepet başarıyla olusturuldu. !");
    }

    [HttpPut]
    public IActionResult UpdateCart(UpdateCartDto cartDto)
    {
        var mapped = _mapper.Map<Cart>(cartDto);
        _cartService.Update(mapped);
        return Ok("Sepet başarıyla güncellendi !");
    }
    
    [HttpDelete]
    [Authorize(Policy = "OnlyAdminUsers")]
    public async Task<IActionResult> DeleteCart(int id)
    {
        var cart = _cartService.GetById(id);
        _cartService.Delete(cart);
        return Ok("Sepet başarıyla silindi !");
    }
    
    [HttpGet("GetProductsFromCart")]
    public async Task<IActionResult> GetProductsFromCart(int cartId)
    {
        var mapped = _mapper.Map<List<ResultCartProductDto>>(_cartService.GetProductsFromCart(cartId));
        return Ok(mapped);
    }

    [HttpPost("PayTheCart")]
    public async Task<IActionResult> PayTheCart(string? couponCode, int cartId, string userId,
        CreditCartRequestDto creditCardDto)
    {
        var result = _cartService.PayTheCart(couponCode, cartId, userId, creditCardDto);
        if (result)
        {
            _orderService.Add(new Order
            {
                OrderDate = DateTime.Now,
                OrderNumber = new Random().Next(1000000, 9999999),
                Status = true,
                CartId = cartId,
                UserId = userId
            });
            return Ok("Ödeme başarıyla yapıldı.");
        }
        return BadRequest("Ödeme başarısız.");
    }
}