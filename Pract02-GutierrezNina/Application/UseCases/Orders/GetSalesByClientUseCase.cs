using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Orders;

public class GetSalesByClientUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSalesByClientUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<SalesByClientDto>> ExecuteAsync() =>
        _unitOfWork.Orders.GetSalesByClientAsync();
}
