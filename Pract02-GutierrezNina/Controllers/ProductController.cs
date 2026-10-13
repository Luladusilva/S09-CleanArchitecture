using Microsoft.AspNetCore.Mvc;
using Pract02_GutierrezNina.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Services.Interfaces;

namespace Pract02_GutierrezNina.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpGet("price-greater-than")]
    public async Task<ActionResult<List<Product>>> GetByMinimumPrice([FromQuery] decimal value = 20) =>
        Ok(await _service.GetByMinimumPriceAsync(value));

    [HttpGet("most-expensive")]
    public async Task<ActionResult<Product>> GetMostExpensive()
    {
        var product = await _service.GetMostExpensiveAsync();
        return product is null ? NotFound() : Ok(product);
    }

    [HttpGet("average-price")]
    public async Task<ActionResult<decimal?>> GetAveragePrice() =>
        Ok(await _service.GetAveragePriceAsync());

    [HttpGet("without-description")]
    public async Task<ActionResult<List<Product>>> GetWithoutDescription() =>
        Ok(await _service.GetWithoutDescriptionAsync());

    [HttpGet("by-order/{orderId:int}")]
    public async Task<ActionResult<List<Product>>> GetByOrder(int orderId) =>
        Ok(await _service.GetByOrderAsync(orderId));

    [HttpGet("sold-to-client/{clientId:int}")]
    public async Task<ActionResult<List<Product>>> GetSoldToClient(int clientId) =>
        Ok(await _service.GetSoldToClientAsync(clientId));

    [HttpPost]
    public async Task<ActionResult<Product>> Create(CreateProductDto product)
    {
        var created = await _service.InsertAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = created.ProductId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductDto product) =>
        await _service.UpdateAsync(id, product) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? NoContent() : NotFound();
}
