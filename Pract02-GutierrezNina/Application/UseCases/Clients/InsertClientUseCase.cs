using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Clients;

public class InsertClientUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public InsertClientUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Client> ExecuteAsync(CreateClientDto cliente)
    {
        var entity = new Client { Name = cliente.Name, Email = cliente.Email };
        await _unitOfWork.Clients.InsertAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return entity;
    }
}
