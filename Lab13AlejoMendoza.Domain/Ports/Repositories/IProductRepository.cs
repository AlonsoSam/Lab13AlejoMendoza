using Lab13AlejoMendoza.Domain.Entities;

namespace Lab13AlejoMendoza.Domain.Ports.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllWithDetailsAsync();
}