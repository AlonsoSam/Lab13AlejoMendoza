using Lab13AlejoMendoza.Application.UseCases.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab13AlejoMendoza.Persistence.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController(IMediator mediator)
    : ControllerBase
{
    [HttpGet("sales")]
    public async Task<IActionResult> GetSalesReport()
    {
        var file = await mediator.Send(
            new GetSalesReportQuery()
        );

        return File(
            file,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "reporte_ventas.xlsx"
        );
    }

    [HttpGet("products")]
    public async Task<IActionResult> GetProductsReport()
    {
        var file = await mediator.Send(
            new GetProductsReportQuery()
        );

        return File(
            file,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "reporte_productos.xlsx"
        );
    }
}