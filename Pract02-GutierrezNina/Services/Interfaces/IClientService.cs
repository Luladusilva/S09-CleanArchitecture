using Pract02_GutierrezNina.Dtos;
using Pract02_GutierrezNina.Models;

namespace Pract02_GutierrezNina.Services.Interfaces;

public interface IClientService
{
    Task<List<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(int id);
    Task<List<Client>> GetByNameAsync(string name);
    Task<List<Client>> GetByProductAsync(int productId);
    Task<List<ClientProductCountDto>> GetClientsWithProductCountAsync();
    Task<Client> InsertAsync(CreateClientDto cliente);
    Task<bool> UpdateAsync(int id, UpdateClientDto cliente);
    Task<bool> DeleteAsync(int id);
}
