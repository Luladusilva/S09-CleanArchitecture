namespace Pract02_GutierrezNina.Repositories.Implements;

using Microsoft.EntityFrameworkCore;
using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(StoreLinQDB context) : base(context)
    {
    }

    public Task<List<Order>> GetAllOrdersAsync() =>
        _dbSet.AsNoTracking().OrderByDescending(order => order.OrderDate).ToListAsync();

    public Task<Order?> GetOrderByIdAsync(int id) =>
        _dbSet.AsNoTracking().FirstOrDefaultAsync(order => order.OrderId == id);

    public Task<List<Order>> GetAfterDateAsync(DateTime date) =>
        _dbSet.AsNoTracking()
            .Where(order => order.OrderDate > DateTime.SpecifyKind(date, DateTimeKind.Unspecified))
            .OrderByDescending(order => order.OrderDate)
            .ToListAsync();

    public Task<int?> GetTotalQuantityAsync(int orderId) =>
        _context.Set<OrderDetail>()
            .Where(detail => detail.OrderId == orderId)
            .Select(detail => (int?)detail.Quantity)
            .SumAsync();

    public Task<List<ClientOrderDto>> GetClientsWithOrdersAsync() =>
        _context.Set<Client>()
            .AsNoTracking()
            .Where(client => client.Orders.Any())
            .Select(client => new ClientOrderDto
            {
                ClientName = client.Name,
                Orders = client.Orders
                    .Select(order => new OrderDto
                    {
                        OrderId = order.OrderId,
                        OrderDate = order.OrderDate
                    })
                    .ToList()
            })
            .ToListAsync();

    public async Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync()
    {
        var mostOrders = await _dbSet.AsNoTracking()
            .GroupBy(order => order.ClientId)
            .Select(group => new
            {
                ClientId = group.Key,
                OrderCount = group.Count()
            })
            .OrderByDescending(item => item.OrderCount)
            .ThenBy(item => item.ClientId)
            .FirstOrDefaultAsync();

        if (mostOrders is null)
            return null;

        return await _context.Set<Client>().AsNoTracking()
            .Where(client => client.ClientId == mostOrders.ClientId)
            .Select(client => new ClientOrderCountDto
            {
                ClientId = client.ClientId,
                ClientName = client.Name,
                OrderCount = mostOrders.OrderCount
            })
            .FirstOrDefaultAsync();
    }

    public Task<List<OrderProductsDto>> GetOrdersWithProductsAsync() =>
        _dbSet.AsNoTracking()
            .OrderByDescending(order => order.OrderDate)
            .Select(order => new OrderProductsDto
            {
                OrderId = order.OrderId,
                ClientName = order.Client.Name,
                OrderDate = order.OrderDate,
                Products = order.OrderDetails
                    .Select(detail => new OrderProductItemDto
                    {
                        ProductName = detail.Product.Name,
                        Quantity = detail.Quantity
                    })
                    .ToList()
            })
            .ToListAsync();

    public Task<List<SalesByClientDto>> GetSalesByClientAsync() =>
        _dbSet.AsNoTracking()
            .GroupBy(order => new { order.ClientId, order.Client.Name })
            .Select(group => new SalesByClientDto
            {
                ClientName = group.Key.Name,
                TotalSales = group.Sum(order => order.OrderDetails.Sum(detail => detail.Quantity * detail.Product.Price))
            })
            .OrderByDescending(sales => sales.TotalSales)
            .ToListAsync();

}