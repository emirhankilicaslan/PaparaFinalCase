using AutoMapper;
using PaparaFinal.DtoLayer.OrderDetailDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Mapper;

public class OrderDetailMapping : Profile
{
    public OrderDetailMapping()
    {
        CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
        CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();
        CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
    }
}