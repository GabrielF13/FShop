using FShop.ProductAPI.DTOs;
using FShop.ProductAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FShop.ProductAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var productsDto = await _productService.GetProducts();
        if (productsDto is null)
            return NotFound("Products not found.");

        return Ok(productsDto);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(int id)
    {
        var productDto = await _productService.GetProductById(id);
        if (productDto is null)
            return NotFound("Product not found.");

        return Ok(productDto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
    {
        if (productDto is null)
            return BadRequest("Invalid Data.");

        await _productService.CreateProduct(productDto);

        return new CreatedAtRouteResult("GetProduct", new { id = productDto.CategoryId }, productDto);
    }

    [HttpPut()]
    public async Task<ActionResult> Put([FromBody] ProductDTO productDto)
    {
        if (productDto is null)
            return BadRequest("Invalid Data.");

        await _productService.UpdateProduct(productDto);

        return Ok(productDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductDTO>> Delete(int id)
    {
        var produtoDto = await _productService.GetProductById(id);

        if (produtoDto == null)
        {
            return NotFound("Product not found");
        }

        await _productService.DeleteProduct(id);

        return Ok(produtoDto);
    }
}
