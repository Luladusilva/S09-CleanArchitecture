using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Orders;

public class GetClientWithMostOrdersUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClientWithMostOrdersUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<ClientOrderCountDto?> ExecuteAsync() =>
        _unitOfWork.Orders.GetClientWithMostOrdersAsync();
}
