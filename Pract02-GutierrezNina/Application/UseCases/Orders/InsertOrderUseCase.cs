using Pract02_GutierrezNina.Application.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Application.UseCases.Orders;

public class InsertOrderUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public InsertOrderUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Order> ExecuteAsync(CreateOrderDto order)
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
}
