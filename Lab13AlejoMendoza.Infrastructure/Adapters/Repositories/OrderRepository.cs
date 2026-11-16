using Lab13AlejoMendoza.Domain.Entities;
using Lab13AlejoMendoza.Domain.Ports.Repositories;
using Lab13AlejoMendoza.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab13AlejoMendoza.Infrastructure.Adapters.Repositories;

public class OrderRepository(AppDbContext context)
    : IOrderRepository
{
    public async Task<List<Order>> GetAllWithDetailsAsync()
    {
        return await context.Orders
            .Include(order => order.Client)
            .Include(order => order.OrderDetails)
            .ThenInclude(detail => detail.Product)
            .ToListAsync();
    }
}