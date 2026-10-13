using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Orders;

public class GetOrdersAfterDateUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrdersAfterDateUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Order>> ExecuteAsync(DateTime date) => _unitOfWork.Orders.GetAfterDateAsync(date);
}
