using Lab13AlejoMendoza.Domain.Ports.Repositories;

namespace Lab13AlejoMendoza.Domain.Ports.UnitOfWork;

public interface IUnitOfWork
{
    IOrderRepository Orders { get; }
    IProductRepository Products { get; }
}