using Microsoft.EntityFrameworkCore;
using Pract02_GutierrezNina.Dtos;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Interfaces;

namespace Pract02_GutierrezNina.Repositories.Implements;

public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(StoreLinQDB context)
        : base(context)
    {
    }

    public Task<List<OrderDetail>> GetAllOrderDetailsAsync() =>
        _dbSet.AsNoTracking()
            .OrderBy(detail => detail.OrderId).ThenBy(detail => detail.OrderDetailId)
            .ToListAsync();

    public Task<OrderDetail?> GetOrderDetailByIdAsync(int id) =>
        _dbSet.AsNoTracking().FirstOrDefaultAsync(detail => detail.OrderDetailId == id);

    public Task<List<OrderDetail>> GetByOrderAsync(int orderId) =>
        _dbSet.AsNoTracking()
            .Where(detail => detail.OrderId == orderId)
            .OrderBy(detail => detail.Product.Name)
            .ToListAsync();
        
    public Task<OrderDetailsDto?> GetOrdersWithDetailsAsync(int orderId) =>
        _context.Set<Order>()
            .Where(order => order.OrderId == orderId)
            .Include(order => order.OrderDetails)
                .ThenInclude(detail => detail.Product)
            .AsNoTracking()
            .Select(order => new OrderDetailsDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                Products = order.OrderDetails
                    .Select(detail => new ProductDto
                    {
                        ProductName = detail.Product.Name,
                        Quantity = detail.Quantity,
                        Price = detail.Product.Price
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

}