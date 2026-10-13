using Pract02_GutierrezNina.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;
using Pract02_GutierrezNina.Services.Interfaces;

namespace Pract02_GutierrezNina.Services.Implements;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Product>> GetAllAsync() => _unitOfWork.Products.GetAllProductsAsync();

    public Task<Product?> GetByIdAsync(int id) => _unitOfWork.Products.GetProductByIdAsync(id);

    public Task<List<Product>> GetByMinimumPriceAsync(decimal minimumPrice) =>
        _unitOfWork.Products.GetByMinimumPriceAsync(minimumPrice);

    public Task<Product?> GetMostExpensiveAsync() => _unitOfWork.Products.GetMostExpensiveAsync();

    public Task<decimal?> GetAveragePriceAsync() => _unitOfWork.Products.GetAveragePriceAsync();

    public Task<List<Product>> GetWithoutDescriptionAsync() => _unitOfWork.Products.GetWithoutDescriptionAsync();

    public Task<List<Product>> GetByOrderAsync(int orderId) => _unitOfWork.Products.GetByOrderAsync(orderId);

    public Task<List<Product>> GetSoldToClientAsync(int clientId) => _unitOfWork.Products.GetSoldToClientAsync(clientId);

    public async Task<Product> InsertAsync(CreateProductDto product)
    {
        var entity = new Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
        await _unitOfWork.Products.InsertAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, UpdateProductDto product)
    {
        var existing = await _unitOfWork.Products.GetByIdAsync(id);
        if (existing is null)
            return false;

        existing.Name = product.Name;
        existing.Description = product.Description;
        existing.Price = product.Price;
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product is null)
            return false;

        _unitOfWork.Products.Delete(product);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
