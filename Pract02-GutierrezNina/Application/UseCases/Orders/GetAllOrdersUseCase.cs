using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Orders;

public class GetAllOrdersUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOrdersUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Order>> ExecuteAsync() => _unitOfWork.Orders.GetAllOrdersAsync();
}
