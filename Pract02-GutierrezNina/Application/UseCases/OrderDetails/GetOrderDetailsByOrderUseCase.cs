using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.OrderDetails;

public class GetOrderDetailsByOrderUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderDetailsByOrderUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<OrderDetail>> ExecuteAsync(int orderId) => _unitOfWork.OrderDetails.GetByOrderAsync(orderId);
}
