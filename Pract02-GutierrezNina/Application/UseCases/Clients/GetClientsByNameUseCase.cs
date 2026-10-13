using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Clients;

public class GetClientsByNameUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClientsByNameUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Client>> ExecuteAsync(string name) => _unitOfWork.Clients.GetByNameAsync(name);
}
