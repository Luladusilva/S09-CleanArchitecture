using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.OrderDetails;

public class GetOrderDetailByIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderDetailByIdUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<OrderDetail?> ExecuteAsync(int id) => _unitOfWork.OrderDetails.GetOrderDetailByIdAsync(id);
}
