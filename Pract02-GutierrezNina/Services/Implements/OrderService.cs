using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;
using Pract02_GutierrezNina.Services.Interfaces;

namespace Pract02_GutierrezNina.Services.Implements;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Order>> GetAllAsync() => _unitOfWork.Orders.GetAllOrdersAsync();

    public Task<Order?> GetByIdAsync(int id) => _unitOfWork.Orders.GetOrderByIdAsync(id);

    public Task<List<Order>> GetAfterDateAsync(DateTime date) => _unitOfWork.Orders.GetAfterDateAsync(date);

    public Task<int?> GetTotalQuantityAsync(int orderId) => _unitOfWork.Orders.GetTotalQuantityAsync(orderId);

    public Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync() =>
        _unitOfWork.Orders.GetClientWithMostOrdersAsync();

    public Task<List<OrderProductsDto>> GetOrdersWithProductsAsync() =>
        _unitOfWork.Orders.GetOrdersWithProductsAsync();

    public Task<List<ClientOrderDto>> GetClientsWithOrdersAsync() =>
        _unitOfWork.Orders.GetClientsWithOrdersAsync();

    public Task<List<SalesByClientDto>> GetSalesByClientAsync() =>
        _unitOfWork.Orders.GetSalesByClientAsync();

    public async Task<Order> InsertAsync(CreateOrderDto order)
    {
        var entity = new Order
        {
            ClientId = order.ClientId,
            OrderDate = DateTime.SpecifyKind(
                order.OrderDate ?? DateTime.UtcNow,
                DateTimeKind.Unspecified),
            OrderDetails = order.Products.Select(item => new OrderDetail
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            }).ToList()
        };
        await _unitOfWork.Orders.InsertAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, UpdateOrderDto order)
    {
        var existing = await _unitOfWork.Orders.GetByIdAsync(id);
        if (existing is null)
            return false;

        existing.ClientId = order.ClientId;
        existing.OrderDate = DateTime.SpecifyKind(order.OrderDate, DateTimeKind.Unspecified);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order is null)
            return false;

        _unitOfWork.Orders.Delete(order);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
