using AutoMapper;
using PaparaFinal.DtoLayer.CategoryDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Mapper;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, ResultCategoryDto>();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
    }
}