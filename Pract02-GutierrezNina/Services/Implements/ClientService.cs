using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;
using Pract02_GutierrezNina.Services.Interfaces;

namespace Pract02_GutierrezNina.Services.Implements;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Client>> GetAllAsync() => _unitOfWork.Clients.GetAllClientsAsync();

    public Task<Client?> GetByIdAsync(int id) => _unitOfWork.Clients.GetClientByIdAsync(id);

    public Task<List<Client>> GetByNameAsync(string name) => _unitOfWork.Clients.GetByNameAsync(name);

    public Task<List<Client>> GetByProductAsync(int productId) => _unitOfWork.Clients.GetByProductAsync(productId);

    public Task<List<ClientProductCountDto>> GetClientsWithProductCountAsync() =>
        _unitOfWork.Clients.GetClientsWithProductCountAsync();

    public async Task<Client> InsertAsync(CreateClientDto cliente)
    {
        var entity = new Client { Name = cliente.Name, Email = cliente.Email };
        await _unitOfWork.Clients.InsertAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, UpdateClientDto cliente)
    {
        var existing = await _unitOfWork.Clients.GetByIdAsync(id);
        if (existing is null)
            return false;

        existing.Name = cliente.Name;
        existing.Email = cliente.Email;
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(id);
        if (client is null)
            return false;

        _unitOfWork.Clients.Delete(client);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
