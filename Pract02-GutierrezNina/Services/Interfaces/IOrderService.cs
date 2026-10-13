using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;

namespace Pract02_GutierrezNina.Services.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<List<Order>> GetAfterDateAsync(DateTime date);
    Task<int?> GetTotalQuantityAsync(int orderId);
    Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync();
    Task<List<OrderProductsDto>> GetOrdersWithProductsAsync();
    Task<List<ClientOrderDto>> GetClientsWithOrdersAsync();
    Task<List<SalesByClientDto>> GetSalesByClientAsync();
    Task<Order> InsertAsync(CreateOrderDto order);
    Task<bool> UpdateAsync(int id, UpdateOrderDto order);
    Task<bool> DeleteAsync(int id);
}
