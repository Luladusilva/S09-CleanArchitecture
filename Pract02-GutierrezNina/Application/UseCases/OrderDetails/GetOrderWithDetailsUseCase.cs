using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.OrderDetails;

public class GetOrderWithDetailsUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderWithDetailsUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<OrderDetailsDto?> ExecuteAsync(int orderId) =>
        _unitOfWork.OrderDetails.GetOrdersWithDetailsAsync(orderId);
}
