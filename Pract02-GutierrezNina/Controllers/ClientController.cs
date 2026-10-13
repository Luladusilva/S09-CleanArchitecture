using Microsoft.AspNetCore.Mvc;
using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Services.Interfaces;

namespace Pract02_GutierrezNina.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<List<Client>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Client>> GetById(int id)
    {
        var client = await _service.GetByIdAsync(id);
        return client is null ? NotFound() : Ok(client);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<Client>>> GetByName([FromQuery] string name) =>
        Ok(await _service.GetByNameAsync(name));

    [HttpGet("by-product/{productId:int}")]
    public async Task<ActionResult<List<Client>>> GetByProduct(int productId) =>
        Ok(await _service.GetByProductAsync(productId));

    [HttpGet("with-product-count")]
    public async Task<ActionResult<List<ClientProductCountDto>>> GetClientsWithProductCount() =>
        Ok(await _service.GetClientsWithProductCountAsync());

    [HttpPost]
    public async Task<ActionResult<Client>> Create(CreateClientDto client)
    {
        var created = await _service.InsertAsync(client);
        return CreatedAtAction(nameof(GetById), new { id = created.ClientId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateClientDto client) =>
        await _service.UpdateAsync(id, client) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? NoContent() : NotFound();
}
