using Lab13AlejoMendoza.Application.Ports.Services;
using Lab13AlejoMendoza.Domain.Ports.Repositories;
using Lab13AlejoMendoza.Domain.Ports.UnitOfWork;
using Lab13AlejoMendoza.Infrastructure.Adapters.Repositories;
using Lab13AlejoMendoza.Infrastructure.Adapters.Services;
using Lab13AlejoMendoza.Infrastructure.Adapters.UnitOfWork;
using Lab13AlejoMendoza.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab13AlejoMendoza.Infrastructure;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString(
                    "DefaultConnection")
            )
        );

        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IReportService, ReportService>();

        return services;
    }
}