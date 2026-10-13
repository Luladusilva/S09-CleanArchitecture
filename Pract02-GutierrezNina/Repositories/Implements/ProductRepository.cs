namespace Pract02_GutierrezNina.Repositories.Implements;

using Microsoft.EntityFrameworkCore;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(StoreLinQDB context) : base(context)
    {
    }

    public Task<List<Product>> GetAllProductsAsync() =>
        _dbSet.AsNoTracking().OrderBy(product => product.ProductId).ToListAsync();

    public Task<Product?> GetProductByIdAsync(int id) =>
        _dbSet.AsNoTracking().FirstOrDefaultAsync(product => product.ProductId == id);

    public Task<List<Product>> GetByMinimumPriceAsync(decimal minimumPrice) =>
        _dbSet.AsNoTracking()
            .Where(product => product.Price > minimumPrice)
            .OrderByDescending(product => product.Price)
            .ToListAsync();

    public Task<Product?> GetMostExpensiveAsync() =>
        _dbSet.AsNoTracking()
            .OrderByDescending(product => product.Price)
            .FirstOrDefaultAsync();

    public Task<decimal?> GetAveragePriceAsync() =>
        _dbSet.Select(product => (decimal?)product.Price).AverageAsync();

    public Task<List<Product>> GetWithoutDescriptionAsync() =>
        _dbSet.AsNoTracking()
            .Where(product => product.Description == null || product.Description.Trim() == "")
            .OrderBy(product => product.Name)
            .ToListAsync();

    public Task<List<Product>> GetByOrderAsync(int orderId) =>
        _context.Set<OrderDetail>().AsNoTracking()
            .Where(detail => detail.OrderId == orderId)
            .Select(detail => detail.Product)
            .Distinct()
            .OrderBy(product => product.Name)
            .ToListAsync();

    public Task<List<Product>> GetSoldToClientAsync(int clientId) =>
        _dbSet.AsNoTracking()
            .Where(product => product.OrderDetails
                .Any(detail => detail.Order.ClientId == clientId))
            .OrderBy(product => product.Name)
            .ToListAsync();
    
}
