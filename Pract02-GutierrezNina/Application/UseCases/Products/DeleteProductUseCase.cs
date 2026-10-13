using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Products;

public class DeleteProductUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product is null)
            return false;

        _unitOfWork.Products.Delete(product);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
