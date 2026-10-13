using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Orders;

public class GetClientsWithOrdersUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClientsWithOrdersUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<ClientOrderDto>> ExecuteAsync() =>
        _unitOfWork.Orders.GetClientsWithOrdersAsync();
}
