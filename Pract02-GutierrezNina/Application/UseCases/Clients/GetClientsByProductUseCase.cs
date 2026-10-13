using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Clients;

public class GetClientsByProductUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClientsByProductUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Client>> ExecuteAsync(int productId) => _unitOfWork.Clients.GetByProductAsync(productId);
}
