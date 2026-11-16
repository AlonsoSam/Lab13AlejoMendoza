using Lab13AlejoMendoza.Application.DTOs.Responses;
using Lab13AlejoMendoza.Application.Ports.Services;
using Lab13AlejoMendoza.Domain.Ports.UnitOfWork;
using MediatR;

namespace Lab13AlejoMendoza.Application.UseCases.Reports.Queries;

public class GetSalesReportQuery : IRequest<byte[]>
{
}

internal class GetSalesReportQueryHandler(
    IUnitOfWork unitOfWork,
    IReportService reportService)
    : IRequestHandler<GetSalesReportQuery, byte[]>
{
    public async Task<byte[]> Handle(
        GetSalesReportQuery request,
        CancellationToken cancellationToken)
    {
        // obtenemos la información necesaria desde el unit of work
        var orders = await unitOfWork.Orders.GetAllWithDetailsAsync();

        // el use case prepara la información del reporte
        var reportData = orders
            .SelectMany(order =>
                order.OrderDetails.Select(detail =>
                    new SalesReportResponseDto
                    {
                        ClientName = order.Client.Name,
                        Email = order.Client.Email,
                        OrderDate = order.OrderDate,

                        ProductName = detail.Product.Name,

                        Quantity = detail.Quantity,
                        UnitPrice = detail.Product.Price,

                        Total = detail.Quantity * detail.Product.Price
                    }))
            .ToList();

        // recién con la información lista llamamos al servicio
        return reportService.CreateSalesReport(reportData);
    }
}