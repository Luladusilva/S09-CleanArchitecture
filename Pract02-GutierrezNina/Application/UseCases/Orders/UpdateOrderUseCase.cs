using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Orders;

public class UpdateOrderUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(int id, UpdateOrderDto order)
    {
        var existing = await _unitOfWork.Orders.GetByIdAsync(id);
        if (existing is null)
            return false;

        existing.ClientId = order.ClientId;
        existing.OrderDate = DateTime.SpecifyKind(order.OrderDate, DateTimeKind.Unspecified);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
