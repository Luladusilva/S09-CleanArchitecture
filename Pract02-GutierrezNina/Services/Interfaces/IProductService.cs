using Pract02_GutierrezNina.Dtos;
using Pract02_GutierrezNina.Models;

namespace Pract02_GutierrezNina.Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<List<Product>> GetByMinimumPriceAsync(decimal minimumPrice);
    Task<Product?> GetMostExpensiveAsync();
    Task<decimal?> GetAveragePriceAsync();
    Task<List<Product>> GetWithoutDescriptionAsync();
    Task<List<Product>> GetByOrderAsync(int orderId);
    Task<List<Product>> GetSoldToClientAsync(int clientId);
    Task<Product> InsertAsync(CreateProductDto product);
    Task<bool> UpdateAsync(int id, UpdateProductDto product);
    Task<bool> DeleteAsync(int id);
}
