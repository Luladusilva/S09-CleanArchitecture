using Microsoft.AspNetCore.Mvc;
using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Application.UseCases.OrderDetails;
using Pract02_GutierrezNina.Models;

namespace Pract02_GutierrezNina.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<OrderDetail>>> GetAll([FromServices] GetAllOrderDetailsUseCase useCase) =>
        Ok(await useCase.ExecuteAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderDetail>> GetById(int id, [FromServices] GetOrderDetailByIdUseCase useCase)
    {
        var detail = await useCase.ExecuteAsync(id);
        return detail is null ? NotFound() : Ok(detail);
    }

    [HttpGet("by-order/{orderId:int}")]
    public async Task<ActionResult<List<OrderDetail>>> GetByOrder(int orderId,
        [FromServices] GetOrderDetailsByOrderUseCase useCase) =>
        Ok(await useCase.ExecuteAsync(orderId));

    [HttpGet("order-with-details/{orderId:int}")]
    public async Task<ActionResult<OrderDetailsDto>> GetOrdersWithDetails(int orderId,
        [FromServices] GetOrderWithDetailsUseCase useCase)
    {
        var order = await useCase.ExecuteAsync(orderId);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDetail>> Create(CreateOrderDetailDto detail,
        [FromServices] InsertOrderDetailUseCase useCase)
    {
        var created = await useCase.ExecuteAsync(detail);
        return CreatedAtAction(nameof(GetById), new { id = created.OrderDetailId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateOrderDetailDto detail,
        [FromServices] UpdateOrderDetailUseCase useCase) =>
        await useCase.ExecuteAsync(id, detail) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, [FromServices] DeleteOrderDetailUseCase useCase) =>
        await useCase.ExecuteAsync(id) ? NoContent() : NotFound();
}
