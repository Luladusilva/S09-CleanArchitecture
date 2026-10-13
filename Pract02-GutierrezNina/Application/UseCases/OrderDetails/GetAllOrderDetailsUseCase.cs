using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.OrderDetails;

public class GetAllOrderDetailsUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOrderDetailsUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<OrderDetail>> ExecuteAsync() => _unitOfWork.OrderDetails.GetAllOrderDetailsAsync();
}
