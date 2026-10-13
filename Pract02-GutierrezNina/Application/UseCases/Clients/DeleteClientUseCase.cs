using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Clients;

public class DeleteClientUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClientUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(int id)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(id);
        if (client is null)
            return false;

        _unitOfWork.Clients.Delete(client);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
