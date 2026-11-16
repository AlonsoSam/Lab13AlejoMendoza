namespace Lab13AlejoMendoza.Application.DTOs.Responses;

public class ProductReportResponseDto
{
    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int TotalQuantity { get; set; }

    public decimal TotalGenerated { get; set; }
}