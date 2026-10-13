namespace Pract02_GutierrezNina.Repositories.Interfaces;

using Pract02_GutierrezNina.Models;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<List<Product>> GetByMinimumPriceAsync(decimal minimumPrice);
    Task<Product?> GetMostExpensiveAsync();
    Task<decimal?> GetAveragePriceAsync();
    Task<List<Product>> GetWithoutDescriptionAsync();
    Task<List<Product>> GetByOrderAsync(int orderId);
    Task<List<Product>> GetSoldToClientAsync(int clientId);
}