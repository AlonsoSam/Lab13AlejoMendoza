namespace Lab13AlejoMendoza.Application.DTOs.Responses;

public class SalesReportResponseDto
{
    public string ClientName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime OrderDate { get; set; }

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Total { get; set; }
}