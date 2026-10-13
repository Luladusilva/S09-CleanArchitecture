using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Orders;

public class GetOrdersWithProductsUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrdersWithProductsUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<OrderProductsDto>> ExecuteAsync() =>
        _unitOfWork.Orders.GetOrdersWithProductsAsync();
}
