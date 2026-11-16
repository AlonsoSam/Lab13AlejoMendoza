using Lab13AlejoMendoza.Application.DTOs.Responses;
using Lab13AlejoMendoza.Application.Ports.Services;
using Lab13AlejoMendoza.Domain.Ports.UnitOfWork;
using MediatR;

namespace Lab13AlejoMendoza.Application.UseCases.Reports.Queries;

public class GetProductsReportQuery : IRequest<byte[]>
{
}

internal class GetProductsReportQueryHandler(
    IUnitOfWork unitOfWork,
    IReportService reportService)
    : IRequestHandler<GetProductsReportQuery, byte[]>
{
    public async Task<byte[]> Handle(
        GetProductsReportQuery request,
        CancellationToken cancellationToken)
    {
        // obtenemos los productos desde el unit of work
        var products = await unitOfWork.Products.GetAllWithDetailsAsync();

        // el use case realiza los cálculos necesarios
        var reportData = products
            .Select(product =>
                new ProductReportResponseDto
                {
                    ProductName = product.Name,
                    Description = product.Description,
                    Price = product.Price,

                    TotalQuantity = product.OrderDetails
                        .Sum(detail => detail.Quantity),

                    TotalGenerated = product.OrderDetails
                        .Sum(detail =>
                            detail.Quantity * product.Price)
                })
            .ToList();

        // el servicio solamente recibe la información preparada
        return reportService.CreateProductsReport(reportData);
    }
}