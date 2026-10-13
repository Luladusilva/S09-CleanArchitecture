namespace Pract02_GutierrezNina.Repositories.Interfaces;

using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;

public interface IOrderRepository : IRepository<Order>
{
    Task<List<Order>> GetAllOrdersAsync();
    Task<Order?> GetOrderByIdAsync(int id);
    Task<List<Order>> GetAfterDateAsync(DateTime date);
    Task<int?> GetTotalQuantityAsync(int orderId);
    Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync();
    Task<List<OrderProductsDto>> GetOrdersWithProductsAsync();
    Task<List<ClientOrderDto>> GetClientsWithOrdersAsync();
    Task<List<SalesByClientDto>> GetSalesByClientAsync();
}