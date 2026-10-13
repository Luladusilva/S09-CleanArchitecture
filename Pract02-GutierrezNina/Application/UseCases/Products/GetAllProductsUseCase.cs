using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Products;

public class GetAllProductsUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductsUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Product>> ExecuteAsync() => _unitOfWork.Products.GetAllProductsAsync();
}
