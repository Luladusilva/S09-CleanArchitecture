using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Products;

public class GetMostExpensiveProductUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMostExpensiveProductUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Product?> ExecuteAsync() => _unitOfWork.Products.GetMostExpensiveAsync();
}
