using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Products;

public class GetAverageProductPriceUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAverageProductPriceUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<decimal?> ExecuteAsync() => _unitOfWork.Products.GetAveragePriceAsync();
}
