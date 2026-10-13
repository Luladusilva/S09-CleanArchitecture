using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Clients;

public class UpdateClientUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClientUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(int id, UpdateClientDto cliente)
    {
        var existing = await _unitOfWork.Clients.GetByIdAsync(id);
        if (existing is null)
            return false;

        existing.Name = cliente.Name;
        existing.Email = cliente.Email;
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
