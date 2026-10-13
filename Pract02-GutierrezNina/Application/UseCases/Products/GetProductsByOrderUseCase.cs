using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Products;

public class GetProductsByOrderUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsByOrderUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Product>> ExecuteAsync(int orderId) => _unitOfWork.Products.GetByOrderAsync(orderId);
}
