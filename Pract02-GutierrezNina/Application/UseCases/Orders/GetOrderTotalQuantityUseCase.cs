using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Orders;

public class GetOrderTotalQuantityUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderTotalQuantityUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<int?> ExecuteAsync(int orderId) => _unitOfWork.Orders.GetTotalQuantityAsync(orderId);
}
