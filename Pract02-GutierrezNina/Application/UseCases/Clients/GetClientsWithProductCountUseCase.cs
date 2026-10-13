using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Clients;

public class GetClientsWithProductCountUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClientsWithProductCountUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<ClientProductCountDto>> ExecuteAsync() =>
        _unitOfWork.Clients.GetClientsWithProductCountAsync();
}
