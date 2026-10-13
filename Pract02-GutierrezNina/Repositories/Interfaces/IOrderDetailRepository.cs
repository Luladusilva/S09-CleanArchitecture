namespace Pract02_GutierrezNina.Repositories.Interfaces;

using Pract02_GutierrezNina.Dtos;
using Pract02_GutierrezNina.Models;

public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    Task<List<OrderDetail>> GetAllOrderDetailsAsync();
    Task<OrderDetail?> GetOrderDetailByIdAsync(int id);
    Task<List<OrderDetail>> GetByOrderAsync(int orderId);
    Task<OrderDetailsDto?> GetOrdersWithDetailsAsync(int orderId);
}