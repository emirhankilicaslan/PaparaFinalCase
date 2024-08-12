using AutoMapper;
using PaparaFinal.DtoLayer.ProductDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Mapper;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, ResultProductDto>();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
    }
}