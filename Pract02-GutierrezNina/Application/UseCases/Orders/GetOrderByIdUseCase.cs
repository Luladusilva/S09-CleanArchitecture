using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Orders;

public class GetOrderByIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderByIdUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Order?> ExecuteAsync(int id) => _unitOfWork.Orders.GetOrderByIdAsync(id);
}
