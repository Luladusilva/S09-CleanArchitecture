using Microsoft.AspNetCore.Mvc;
using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Services.Interfaces;

namespace Pract02_GutierrezNina.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Order>> GetById(int id)
    {
        var order = await _service.GetByIdAsync(id);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpGet("after-date")]
    public async Task<ActionResult<List<Order>>> GetAfterDate([FromQuery] DateTime date) =>
        Ok(await _service.GetAfterDateAsync(date));

    [HttpGet("{id:int}/total-quantity")]
    public async Task<ActionResult<int>> GetTotalQuantity(int id)
    {
        var quantity = await _service.GetTotalQuantityAsync(id);
        return quantity is null ? NotFound() : Ok(quantity.Value);
    }

    [HttpGet("client-with-most-orders")]
    public async Task<ActionResult<ClientOrderCountDto>> GetClientWithMostOrders()
    {
        var client = await _service.GetClientWithMostOrdersAsync();
        return client is null ? NotFound() : Ok(client);
    }

    [HttpGet("products")]
    public async Task<ActionResult<List<OrderProductsDto>>> GetOrdersWithProducts() =>
        Ok(await _service.GetOrdersWithProductsAsync());

    [HttpGet("clients-with-orders")]
    public async Task<ActionResult<List<ClientOrderDto>>> GetClientsWithOrders() =>
        Ok(await _service.GetClientsWithOrdersAsync());

    [HttpGet("sales-by-client")]
    public async Task<ActionResult<List<SalesByClientDto>>> GetSalesByClient() =>
        Ok(await _service.GetSalesByClientAsync());

    [HttpPost]
    public async Task<ActionResult<Order>> Create(CreateOrderDto order)
    {
        var created = await _service.InsertAsync(order);
        return CreatedAtAction(nameof(GetById), new { id = created.OrderId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateOrderDto order) =>
        await _service.UpdateAsync(id, order) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? NoContent() : NotFound();
}
