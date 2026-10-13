using Pract02_GutierrezNina.Repositories.Interfaces;
using Pract02_GutierrezNina.Models;

namespace Pract02_GutierrezNina.Repositories.Implements;

public class UnitOfWork : IUnitOfWork
{
    private readonly StoreLinQDB _context;

    public IProductRepository Products { get; }
    public IClientRepository Clients { get; }
    public IOrderDetailRepository OrderDetails { get; }
    public IOrderRepository Orders { get; }

    public UnitOfWork(
        StoreLinQDB context,
        IProductRepository productRepository,
        IClientRepository clientRepository,
        IOrderDetailRepository orderDetailRepository,
        IOrderRepository orderRepository)
    {
        _context = context;

        Products = productRepository;
        Clients = clientRepository;
        OrderDetails = orderDetailRepository;
        Orders = orderRepository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}