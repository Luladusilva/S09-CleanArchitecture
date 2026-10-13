using Microsoft.EntityFrameworkCore;
using Pract02_GutierrezNina.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Repositories.Implements;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(StoreLinQDB context)
        : base(context)
    {
    }

    public Task<List<Client>> GetAllClientsAsync() =>
        _dbSet.AsNoTracking().OrderBy(client => client.ClientId).ToListAsync();

    public Task<Client?> GetClientByIdAsync(int id) =>
        _dbSet.AsNoTracking().FirstOrDefaultAsync(client => client.ClientId == id);

    public Task<List<Client>> GetByNameAsync(string name) =>
        _dbSet.AsNoTracking()
            .Where(client => client.Name.StartsWith(name))
            .OrderBy(client => client.Name)
            .ToListAsync();

    public Task<List<Client>> GetByProductAsync(int productId) =>
        _dbSet.AsNoTracking()
            .Where(client => client.Orders
                .Any(order => order.OrderDetails.Any(detail => detail.ProductId == productId)))
            .OrderBy(client => client.Name)
            .ToListAsync();

    public Task<List<ClientProductCountDto>> GetClientsWithProductCountAsync() =>
        _dbSet
            .AsNoTracking()
            .Select(client => new ClientProductCountDto
            {
                ClientName = client.Name,
                TotalProducts = client.Orders
                    .SelectMany(order => order.OrderDetails)
                    .Sum(detail => (int?)detail.Quantity) ?? 0
            })
            .ToListAsync();
}