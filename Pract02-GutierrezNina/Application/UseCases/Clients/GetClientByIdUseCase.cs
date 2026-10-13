using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Clients;

public class GetClientByIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClientByIdUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Client?> ExecuteAsync(int id) => _unitOfWork.Clients.GetClientByIdAsync(id);
}
