using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Products;

public class GetProductsSoldToClientUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsSoldToClientUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Product>> ExecuteAsync(int clientId) => _unitOfWork.Products.GetSoldToClientAsync(clientId);
}
