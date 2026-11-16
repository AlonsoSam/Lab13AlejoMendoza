using Lab13AlejoMendoza.Domain.Entities;

namespace Lab13AlejoMendoza.Domain.Ports.Repositories;

public interface IOrderRepository
{
    Task<List<Order>> GetAllWithDetailsAsync();
}