using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DtoLayer.CategoryDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var mapped = _mapper.Map<List<ResultCategoryDto>>(_categoryService.GetAll());
        return Ok(mapped);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var entity = _categoryService.GetById(id);
        return Ok(entity);
    }

    [HttpPost]
    public  IActionResult CreateCategory(CreateCategoryDto categoryDto)
    {
        var mapped = _mapper.Map<Category>(categoryDto);
        _categoryService.Add(mapped);
        return Ok("Kategori başarıyla eklendi !");
    }

    [HttpPut]
    public IActionResult UpdateCategory(UpdateCategoryDto categoryDto)
    {
        var mapped = _mapper.Map<Category>(categoryDto);
        _categoryService.Update(mapped);
        return Ok("Kategori başarıyla güncellendi !");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = _categoryService.GetById(id);
        _categoryService.Delete(category);
        return Ok("Kategori başarıyla silindi !");
    }
    
    [HttpGet("GetActiveCategoryList")]
    public async Task<IActionResult> GetActiveCategoryList()
    {
        var mapped = _mapper.Map<List<ResultCategoryDto>>(_categoryService.GetActiveCategoryList());
        return Ok(mapped);
    }
    [HttpPost("AddCategoryToProduct")]
    public async Task<IActionResult> AddCategoryToProduct(int productId, int categoryId)
    {
        _categoryService.AddCategoryToProduct(productId, categoryId);
        return Ok("Kategori - Ürün eşleştirildi.");
    }
}