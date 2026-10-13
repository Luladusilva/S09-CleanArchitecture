using Microsoft.AspNetCore.Mvc;
using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Application.UseCases.Orders;
using Pract02_GutierrezNina.Models;

namespace Pract02_GutierrezNina.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetAll([FromServices] GetAllOrdersUseCase useCase) =>
        Ok(await useCase.ExecuteAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Order>> GetById(int id, [FromServices] GetOrderByIdUseCase useCase)
    {
        var order = await useCase.ExecuteAsync(id);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpGet("after-date")]
    public async Task<ActionResult<List<Order>>> GetAfterDate([FromQuery] DateTime date,
        [FromServices] GetOrdersAfterDateUseCase useCase) =>
        Ok(await useCase.ExecuteAsync(date));

    [HttpGet("{id:int}/total-quantity")]
    public async Task<ActionResult<int>> GetTotalQuantity(int id, [FromServices] GetOrderTotalQuantityUseCase useCase)
    {
        var quantity = await useCase.ExecuteAsync(id);
        return quantity is null ? NotFound() : Ok(quantity.Value);
    }

    [HttpGet("client-with-most-orders")]
    public async Task<ActionResult<ClientOrderCountDto>> GetClientWithMostOrders(
        [FromServices] GetClientWithMostOrdersUseCase useCase)
    {
        var client = await useCase.ExecuteAsync();
        return client is null ? NotFound() : Ok(client);
    }

    [HttpGet("products")]
    public async Task<ActionResult<List<OrderProductsDto>>> GetOrdersWithProducts(
        [FromServices] GetOrdersWithProductsUseCase useCase) =>
        Ok(await useCase.ExecuteAsync());

    [HttpGet("clients-with-orders")]
    public async Task<ActionResult<List<ClientOrderDto>>> GetClientsWithOrders(
        [FromServices] GetClientsWithOrdersUseCase useCase) =>
        Ok(await useCase.ExecuteAsync());

    [HttpGet("sales-by-client")]
    public async Task<ActionResult<List<SalesByClientDto>>> GetSalesByClient(
        [FromServices] GetSalesByClientUseCase useCase) =>
        Ok(await useCase.ExecuteAsync());

    [HttpPost]
    public async Task<ActionResult<Order>> Create(CreateOrderDto order, [FromServices] InsertOrderUseCase useCase)
    {
        var created = await useCase.ExecuteAsync(order);
        return CreatedAtAction(nameof(GetById), new { id = created.OrderId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateOrderDto order, [FromServices] UpdateOrderUseCase useCase) =>
        await useCase.ExecuteAsync(id, order) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, [FromServices] DeleteOrderUseCase useCase) =>
        await useCase.ExecuteAsync(id) ? NoContent() : NotFound();
}
