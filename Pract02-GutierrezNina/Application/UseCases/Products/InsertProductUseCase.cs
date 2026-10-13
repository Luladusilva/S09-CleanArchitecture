using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Products;

public class InsertProductUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public InsertProductUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> ExecuteAsync(CreateProductDto product)
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
}
