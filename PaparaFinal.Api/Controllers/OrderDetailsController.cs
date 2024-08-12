using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DtoLayer.OrderDetailDtos;
using PaparaFinal.EntityLayer.Entities;


namespace PaparaFinal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;
    private readonly IMapper _mapper;

    public OrderDetailsController(IOrderDetailService orderDetailService, IMapper mapper)
    {
        _orderDetailService = orderDetailService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list =_mapper.Map<List<ResultOrderDetailDto>>( _orderDetailService.GetAll());
        return Ok(list);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var entity = _orderDetailService.GetById(id);
        return Ok(entity);
    }

    [HttpPost]
    public  IActionResult CreateOrderDetail(CreateOrderDetailDto orderDetailDto)
    {
        var mapped = _mapper.Map<OrderDetail>(orderDetailDto);
        _orderDetailService.Add(mapped);
        return Ok("Sipariş detayı başarıyla eklendi !");
    }

    [HttpPut]
    public IActionResult UpdateOrderDetail(UpdateOrderDetailDto orderDetailDto)
    {
        var mapped = _mapper.Map<OrderDetail>(orderDetailDto);
        _orderDetailService.Update(mapped);
        return Ok("Sipariş detayı başarıyla güncellendi !");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        var orderDetail = _orderDetailService.GetById(id);
        _orderDetailService.Delete(orderDetail);
        return Ok("Sipariş detayı başarıyla silindi !");
    }
}