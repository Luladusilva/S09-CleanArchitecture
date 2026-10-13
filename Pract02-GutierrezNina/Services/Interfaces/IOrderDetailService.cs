using Pract02_GutierrezNina.Dtos;
using Pract02_GutierrezNina.Models;

namespace Pract02_GutierrezNina.Services.Interfaces;

public interface IOrderDetailService
{
    Task<List<OrderDetail>> GetAllAsync();
    Task<OrderDetail?> GetByIdAsync(int id);
    Task<List<OrderDetail>> GetByOrderAsync(int orderId);
    Task<OrderDetailsDto?> GetOrdersWithDetailsAsync(int orderId);
    Task<OrderDetail> InsertAsync(CreateOrderDetailDto detail);
    Task<bool> UpdateAsync(int id, UpdateOrderDetailDto detail);
    Task<bool> DeleteAsync(int id);
}
