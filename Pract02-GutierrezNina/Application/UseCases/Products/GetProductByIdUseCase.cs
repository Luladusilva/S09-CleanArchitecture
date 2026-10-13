using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Products;

public class GetProductByIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductByIdUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Product?> ExecuteAsync(int id) => _unitOfWork.Products.GetProductByIdAsync(id);
}
