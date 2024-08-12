using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaFinal.BusinessLayer.Abstract;
using PaparaFinal.DtoLayer.ProductDtos;
using PaparaFinal.DtoLayer.UserDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "OnlyAdminUsers")]
public class ProductsController : ControllerBase
{
    
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = _mapper.Map<List<ResultProductDto>>( _productService.GetAll());
        return Ok(list);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var entity = _productService.GetById(id);
        return Ok(entity);
    }

    [HttpPost]
    public  IActionResult CreateProduct(CreateProductDto productDto)
    {
        var mapped = _mapper.Map<Product>(productDto);
        _productService.Add(mapped);
        return Ok("Ürün başarıyla eklendi !");
    }

    [HttpPut]
    public IActionResult UpdateProduct(UpdateProductDto productDto)
    {
        var mapped = _mapper.Map<Product>(productDto);
        _productService.Update(mapped);
        return Ok("Ürün başarıyla güncellendi !");
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = _productService.GetById(id);
        _productService.Delete(product);
        return Ok("Ürün başarıyla silindi !");
    }

    [HttpGet("GetProductsOnSale")]
    public async Task<IActionResult> GetProductsOnSale()
    {
        var products = _mapper.Map<List<ResultProductDto>>( _productService.GetProductsOnSale());
        return Ok(products);
    }
    [HttpPost("ChangeUnitsInStock")]
    public async Task<IActionResult> ChangeUnitsInStock(int stockQuantity, int productId)
    {
        _productService.ChangeUnitsInStock(stockQuantity, productId);
        return Ok("Stok bilgisi güncellendi !");
    }
    
    [HttpGet("GetProductsByCategoryName")]
    public async Task<IActionResult> GetProductsByCategoryName(string categoryName)
    {
        var products = _mapper.Map<List<ResultProductDto>>(_productService.GetProductsByCategoryName(categoryName));
        return Ok(products);
    }
    
    [HttpPost("AddProductToCategory")]
    public async Task<IActionResult> AddProductToCategory(int productId, int categoryId)
    {
        _productService.AddProductToCategory(productId, categoryId);
        return Ok("Ürün - kategori eşleştirildi.");
    }
    
    [HttpPost("AddProductToCart")]
    public async Task<IActionResult> AddProductToCart(int cartId, int productId, int quantity)
    {
        _productService.AddProductToCart(cartId, productId, quantity);
        return Ok("Ürün sepete eklendi.");
    }
}