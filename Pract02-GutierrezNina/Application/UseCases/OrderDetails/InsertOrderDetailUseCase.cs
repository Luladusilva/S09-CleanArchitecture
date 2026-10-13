using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.OrderDetails;

public class InsertOrderDetailUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public InsertOrderDetailUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OrderDetail> ExecuteAsync(CreateOrderDetailDto detail)
    {
        var entity = new OrderDetail
        {
            OrderId = detail.OrderId,
            ProductId = detail.ProductId,
            Quantity = detail.Quantity
        };
        await _unitOfWork.OrderDetails.InsertAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return entity;
    }
}
