using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Products;

public class GetProductsByMinimumPriceUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsByMinimumPriceUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Product>> ExecuteAsync(decimal minimumPrice) =>
        _unitOfWork.Products.GetByMinimumPriceAsync(minimumPrice);
}
