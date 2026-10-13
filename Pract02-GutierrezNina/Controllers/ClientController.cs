using Microsoft.AspNetCore.Mvc;
using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Application.UseCases.Clients;
using Pract02_GutierrezNina.Models;

namespace Pract02_GutierrezNina.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Client>>> GetAll([FromServices] GetAllClientsUseCase useCase) =>
        Ok(await useCase.ExecuteAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Client>> GetById(int id, [FromServices] GetClientByIdUseCase useCase)
    {
        var client = await useCase.ExecuteAsync(id);
        return client is null ? NotFound() : Ok(client);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<Client>>> GetByName([FromQuery] string name,
        [FromServices] GetClientsByNameUseCase useCase) =>
        Ok(await useCase.ExecuteAsync(name));

    [HttpGet("by-product/{productId:int}")]
    public async Task<ActionResult<List<Client>>> GetByProduct(int productId,
        [FromServices] GetClientsByProductUseCase useCase) =>
        Ok(await useCase.ExecuteAsync(productId));

    [HttpGet("with-product-count")]
    public async Task<ActionResult<List<ClientProductCountDto>>> GetClientsWithProductCount(
        [FromServices] GetClientsWithProductCountUseCase useCase) =>
        Ok(await useCase.ExecuteAsync());

    [HttpPost]
    public async Task<ActionResult<Client>> Create(CreateClientDto client, [FromServices] InsertClientUseCase useCase)
    {
        var created = await useCase.ExecuteAsync(client);
        return CreatedAtAction(nameof(GetById), new { id = created.ClientId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateClientDto client,
        [FromServices] UpdateClientUseCase useCase) =>
        await useCase.ExecuteAsync(id, client) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, [FromServices] DeleteClientUseCase useCase) =>
        await useCase.ExecuteAsync(id) ? NoContent() : NotFound();
}
