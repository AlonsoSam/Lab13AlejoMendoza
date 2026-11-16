using Lab13AlejoMendoza.Domain.Ports.Repositories;
using Lab13AlejoMendoza.Domain.Ports.UnitOfWork;

namespace Lab13AlejoMendoza.Infrastructure.Adapters.UnitOfWork;

public class UnitOfWork(
    IOrderRepository orderRepository,
    IProductRepository productRepository)
    : IUnitOfWork
{
    public IOrderRepository Orders { get; } = orderRepository;

    public IProductRepository Products { get; } = productRepository;
}