using Microsoft.AspNetCore.Mvc;
using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Application.UseCases.Products;
using Pract02_GutierrezNina.Models;

namespace Pract02_GutierrezNina.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll([FromServices] GetAllProductsUseCase useCase) =>
        Ok(await useCase.ExecuteAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id, [FromServices] GetProductByIdUseCase useCase)
    {
        var product = await useCase.ExecuteAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpGet("price-greater-than")]
    public async Task<ActionResult<List<Product>>> GetByMinimumPrice(
        [FromServices] GetProductsByMinimumPriceUseCase useCase, [FromQuery] decimal value = 20) =>
        Ok(await useCase.ExecuteAsync(value));

    [HttpGet("most-expensive")]
    public async Task<ActionResult<Product>> GetMostExpensive([FromServices] GetMostExpensiveProductUseCase useCase)
    {
        var product = await useCase.ExecuteAsync();
        return product is null ? NotFound() : Ok(product);
    }

    [HttpGet("average-price")]
    public async Task<ActionResult<decimal?>> GetAveragePrice([FromServices] GetAverageProductPriceUseCase useCase) =>
        Ok(await useCase.ExecuteAsync());

    [HttpGet("without-description")]
    public async Task<ActionResult<List<Product>>> GetWithoutDescription(
        [FromServices] GetProductsWithoutDescriptionUseCase useCase) =>
        Ok(await useCase.ExecuteAsync());

    [HttpGet("by-order/{orderId:int}")]
    public async Task<ActionResult<List<Product>>> GetByOrder(int orderId,
        [FromServices] GetProductsByOrderUseCase useCase) =>
        Ok(await useCase.ExecuteAsync(orderId));

    [HttpGet("sold-to-client/{clientId:int}")]
    public async Task<ActionResult<List<Product>>> GetSoldToClient(int clientId,
        [FromServices] GetProductsSoldToClientUseCase useCase) =>
        Ok(await useCase.ExecuteAsync(clientId));

    [HttpPost]
    public async Task<ActionResult<Product>> Create(CreateProductDto product,
        [FromServices] InsertProductUseCase useCase)
    {
        var created = await useCase.ExecuteAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = created.ProductId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductDto product,
        [FromServices] UpdateProductUseCase useCase) =>
        await useCase.ExecuteAsync(id, product) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, [FromServices] DeleteProductUseCase useCase) =>
        await useCase.ExecuteAsync(id) ? NoContent() : NotFound();
}
