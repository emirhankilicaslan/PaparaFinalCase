using AutoMapper;
using PaparaFinal.DtoLayer.OrderDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Mapper;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<Order, CreateOrderDto>().ReverseMap();
        CreateMap<Order, UpdateOrderDto>().ReverseMap();
        CreateMap<Order, ResultOrderDto>();
    }
}