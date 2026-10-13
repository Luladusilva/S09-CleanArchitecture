using Pract02_GutierrezNina.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;
using Pract02_GutierrezNina.Services.Interfaces;

namespace Pract02_GutierrezNina.Services.Implements;

public class OrderDetailService : IOrderDetailService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderDetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<OrderDetail>> GetAllAsync() => _unitOfWork.OrderDetails.GetAllOrderDetailsAsync();

    public Task<OrderDetail?> GetByIdAsync(int id) => _unitOfWork.OrderDetails.GetOrderDetailByIdAsync(id);

    public Task<List<OrderDetail>> GetByOrderAsync(int orderId) => _unitOfWork.OrderDetails.GetByOrderAsync(orderId);

    public Task<OrderDetailsDto?> GetOrdersWithDetailsAsync(int orderId) =>
        _unitOfWork.OrderDetails.GetOrdersWithDetailsAsync(orderId);

    public async Task<OrderDetail> InsertAsync(CreateOrderDetailDto detail)
    {
        var entity = new OrderDetail
        {
            OrderId = detail.OrderId,
            ProductId = detail.ProductId,
            Quantity = detail.Quantity
        };
        await _unitOfWork.OrderDetails.InsertAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, UpdateOrderDetailDto detail)
    {
        var existing = await _unitOfWork.OrderDetails.GetByIdAsync(id);
        if (existing is null)
            return false;

        existing.OrderId = detail.OrderId;
        existing.ProductId = detail.ProductId;
        existing.Quantity = detail.Quantity;
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var detail = await _unitOfWork.OrderDetails.GetByIdAsync(id);
        if (detail is null)
            return false;

        _unitOfWork.OrderDetails.Delete(detail);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
