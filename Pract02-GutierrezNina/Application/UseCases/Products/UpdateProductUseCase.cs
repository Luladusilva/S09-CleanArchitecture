using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Products;

public class UpdateProductUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(int id, UpdateProductDto product)
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
}
