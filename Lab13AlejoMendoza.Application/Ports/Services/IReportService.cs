using Lab13AlejoMendoza.Application.DTOs.Responses;

namespace Lab13AlejoMendoza.Application.Ports.Services;

public interface IReportService
{
    byte[] CreateSalesReport(
        List<SalesReportResponseDto> data);

    byte[] CreateProductsReport(
        List<ProductReportResponseDto> data);
}