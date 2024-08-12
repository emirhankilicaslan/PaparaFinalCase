using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DtoLayer.OrderDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [Authorize(Policy = "OnlyAdminUsers")]
    public async Task<IActionResult> GetAll()
    {
        var mapped = _mapper.Map<List<ResultOrderDto>>(_orderService.GetAll());
        return Ok(mapped);
    }
    
    [HttpGet("{id}")]
    [Authorize(Policy = "OnlyAdminUsers")]
    public IActionResult GetById(int id)
    {
        var mapped = _mapper.Map<ResultOrderDto>(_orderService.GetById(id));
        return Ok(mapped);
    }

    [HttpPost]
    public  IActionResult CreateOrder(CreateOrderDto orderDto)
    {
        var mapped = _mapper.Map<Order>(orderDto);
        _orderService.Add(mapped);
        return Ok("Sipariş başarıyla eklendi !");
    }

    [HttpPut]
    [Authorize(Policy = "OnlyAdminUsers")]
    public IActionResult UpdateOrder(UpdateOrderDto orderDto)
    {
        var mapped = _mapper.Map<Order>(orderDto);
        _orderService.Update(mapped);
        return Ok("Sipariş başarıyla güncellendi !");
    }
    
    [HttpDelete]
    [Authorize(Policy = "OnlyAdminUsers")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = _orderService.GetById(id);
        _orderService.Delete(order);
        return Ok("Sipariş başarıyla silindi !");
    }
    
    [HttpGet("GetPastOrders")]
    [Authorize(Policy = "OnlyAdminUsers")]
    public async Task<IActionResult> GetPastOrders()
    {
        var mapped = _mapper.Map<List<ResultOrderDto>>(_orderService.GetPastOrders());
        return Ok(mapped);
    }
    
    [HttpGet("GetActiveOrders")]
    [Authorize(Policy = "OnlyAdminUsers")]
    public async Task<IActionResult> GetActiveOrders()
    {
        var mapped = _mapper.Map<List<ResultOrderDto>>(_orderService.GetActiveOrders());
        return Ok(mapped);
    }
    
    [HttpPost("ChangeOrderStatusToFalse")]
    [Authorize(Policy = "OnlyAdminUsers")]
    public async Task<IActionResult> ChangeOrderStatusToFalse(int orderId)
    {
        _orderService.ChangeOrderStatusToFalse(orderId);
        return Ok("Sipariş statüsü değiştirildi !");
    }
}