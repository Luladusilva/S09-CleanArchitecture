using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Products;

public class GetProductsWithoutDescriptionUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsWithoutDescriptionUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Product>> ExecuteAsync() => _unitOfWork.Products.GetWithoutDescriptionAsync();
}
