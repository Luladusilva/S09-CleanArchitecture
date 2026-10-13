using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.OrderDetails;

public class DeleteOrderDetailUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderDetailUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(int id)
    {
        var detail = await _unitOfWork.OrderDetails.GetByIdAsync(id);
        if (detail is null)
            return false;

        _unitOfWork.OrderDetails.Delete(detail);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
