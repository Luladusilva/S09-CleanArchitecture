using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Clients;

public class GetAllClientsUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllClientsUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Client>> ExecuteAsync() => _unitOfWork.Clients.GetAllClientsAsync();
}
