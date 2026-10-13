using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Orders;

public class DeleteOrderUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order is null)
            return false;

        _unitOfWork.Orders.Delete(order);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
