using Microsoft.AspNetCore.Mvc;
using Pract02_GutierrezNina.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Services.Interfaces;

namespace Pract02_GutierrezNina.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailService _service;

    public OrderDetailController(IOrderDetailService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<List<OrderDetail>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderDetail>> GetById(int id)
    {
        var detail = await _service.GetByIdAsync(id);
        return detail is null ? NotFound() : Ok(detail);
    }

    [HttpGet("by-order/{orderId:int}")]
    public async Task<ActionResult<List<OrderDetail>>> GetByOrder(int orderId) =>
        Ok(await _service.GetByOrderAsync(orderId));

    [HttpGet("order-with-details/{orderId:int}")]
    public async Task<ActionResult<OrderDetailsDto>> GetOrdersWithDetails(int orderId)
    {
        var order = await _service.GetOrdersWithDetailsAsync(orderId);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDetail>> Create(CreateOrderDetailDto detail)
    {
        var created = await _service.InsertAsync(detail);
        return CreatedAtAction(nameof(GetById), new { id = created.OrderDetailId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateOrderDetailDto detail) =>
        await _service.UpdateAsync(id, detail) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? NoContent() : NotFound();
}
