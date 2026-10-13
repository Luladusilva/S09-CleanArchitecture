namespace Pract02_GutierrezNina.Repositories.Interfaces;

using Pract02_GutierrezNina.Dtos;
using Pract02_GutierrezNina.Models;

public interface IClientRepository : IRepository<Client>
{
    Task<List<Client>> GetAllClientsAsync();
    Task<Client?> GetClientByIdAsync(int id);
    Task<List<Client>> GetByNameAsync(string name);
    Task<List<Client>> GetByProductAsync(int productId);
    Task<List<ClientProductCountDto>> GetClientsWithProductCountAsync();
}