using Lab13AlejoMendoza.Domain.Entities;
using Lab13AlejoMendoza.Domain.Ports.Repositories;
using Lab13AlejoMendoza.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab13AlejoMendoza.Infrastructure.Adapters.Repositories;

public class ProductRepository(AppDbContext context)
    : IProductRepository
{
    public async Task<List<Product>> GetAllWithDetailsAsync()
    {
        return await context.Products
            .Include(product => product.OrderDetails)
            .ToListAsync();
    }
}