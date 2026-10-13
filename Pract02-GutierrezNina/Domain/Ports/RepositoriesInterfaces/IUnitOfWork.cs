namespace Pract02_GutierrezNina.Repositories.Interfaces;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    IClientRepository Clients { get; }
    IOrderDetailRepository OrderDetails { get; }
    IOrderRepository Orders { get; }

    Task<int> SaveChangesAsync();
}
