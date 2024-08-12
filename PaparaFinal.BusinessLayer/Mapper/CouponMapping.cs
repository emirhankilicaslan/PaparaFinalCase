using AutoMapper;
using PaparaFinal.DtoLayer.CouponDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Mapper;

public class CouponMapping : Profile
{
    public CouponMapping()
    {
        CreateMap<CreateCouponDto, Coupon>()
            .ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId));
        CreateMap<Coupon, ResultCouponDto>().ReverseMap();
        CreateMap<Coupon, UpdateCouponDto>().ReverseMap();
    }
}