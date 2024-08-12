using AutoMapper;
using PaparaFinal.DtoLayer.CartDtos;
using PaparaFinal.DtoLayer.ProductDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Mapper;

public class CartMapping : Profile
{
    public CartMapping()
    {
        CreateMap<CreateCartDto, Cart>().ReverseMap();
        CreateMap<Cart, UpdateCartDto>().ReverseMap();
        CreateMap<Cart, ResultCartDto>()
            .ForMember(dest => dest.Products,
                opt => opt
                    .MapFrom(src => src.CartProducts.Select(cp => new ResultProductDto
                    {
                        Id = cp.Product.Id,
                        Name = cp.Product.Name,
                        Description = cp.Product.Description,
                        Price = cp.Product.Price,
                        UnitsInStock = cp.Product.UnitsInStock,
                        IsActive = cp.Product.IsActive
                    }).ToList()));
    }
}