using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.OrderDetails;

public class UpdateOrderDetailUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderDetailUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(int id, UpdateOrderDetailDto detail)
    {
        var existing = await _unitOfWork.OrderDetails.GetByIdAsync(id);
        if (existing is null)
            return false;

        existing.OrderId = detail.OrderId;
        existing.ProductId = detail.ProductId;
        existing.Quantity = detail.Quantity;
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
