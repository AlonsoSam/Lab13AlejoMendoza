using ClosedXML.Excel;
using Lab13AlejoMendoza.Application.DTOs.Responses;
using Lab13AlejoMendoza.Application.Ports.Services;

namespace Lab13AlejoMendoza.Infrastructure.Adapters.Services;

public class ReportService : IReportService
{
    public byte[] CreateSalesReport(
        List<SalesReportResponseDto> data)
    {
        using var workbook = new XLWorkbook();

        var worksheet =
            workbook.Worksheets.Add("Ventas por cliente");

        // encabezados
        worksheet.Cell(1, 1).Value = "Cliente";
        worksheet.Cell(1, 2).Value = "Email";
        worksheet.Cell(1, 3).Value = "Fecha";
        worksheet.Cell(1, 4).Value = "Producto";
        worksheet.Cell(1, 5).Value = "Cantidad";
        worksheet.Cell(1, 6).Value = "Precio Unitario";
        worksheet.Cell(1, 7).Value = "Total";

        var row = 2;

        foreach (var item in data)
        {
            worksheet.Cell(row, 1).Value = item.ClientName;
            worksheet.Cell(row, 2).Value = item.Email;
            worksheet.Cell(row, 3).Value = item.OrderDate;
            worksheet.Cell(row, 4).Value = item.ProductName;
            worksheet.Cell(row, 5).Value = item.Quantity;
            worksheet.Cell(row, 6).Value = item.UnitPrice;
            worksheet.Cell(row, 7).Value = item.Total;

            row++;
        }

        // formato de los encabezados
        var header = worksheet.Range("A1:G1");

        header.Style.Font.Bold = true;
        header.Style.Fill.BackgroundColor = XLColor.LightBlue;
        header.Style.Alignment.Horizontal =
            XLAlignmentHorizontalValues.Center;

        // formatos
        worksheet.Column(3)
            .Style.DateFormat.Format = "dd/MM/yyyy";

        worksheet.Columns(6, 7)
            .Style.NumberFormat.Format = "S/ #,##0.00";

        // crear tabla
        if (data.Count > 0)
        {
            var range = worksheet.Range(
                1,
                1,
                data.Count + 1,
                7
            );

            range.CreateTable();
        }

        worksheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }


    public byte[] CreateProductsReport(
        List<ProductReportResponseDto> data)
    {
        using var workbook = new XLWorkbook();

        var worksheet =
            workbook.Worksheets.Add("Productos vendidos");

        // encabezados
        worksheet.Cell(1, 1).Value = "Producto";
        worksheet.Cell(1, 2).Value = "Descripción";
        worksheet.Cell(1, 3).Value = "Precio";
        worksheet.Cell(1, 4).Value = "Cantidad vendida";
        worksheet.Cell(1, 5).Value = "Total generado";

        var row = 2;

        foreach (var item in data)
        {
            worksheet.Cell(row, 1).Value = item.ProductName;
            worksheet.Cell(row, 2).Value = item.Description ?? "";
            worksheet.Cell(row, 3).Value = item.Price;
            worksheet.Cell(row, 4).Value = item.TotalQuantity;
            worksheet.Cell(row, 5).Value = item.TotalGenerated;

            row++;
        }

        // formato de los encabezados
        var header = worksheet.Range("A1:E1");

        header.Style.Font.Bold = true;
        header.Style.Fill.BackgroundColor = XLColor.LightBlue;
        header.Style.Alignment.Horizontal =
            XLAlignmentHorizontalValues.Center;

        worksheet.Column(3)
            .Style.NumberFormat.Format = "S/ #,##0.00";

        worksheet.Column(5)
            .Style.NumberFormat.Format = "S/ #,##0.00";

        // crear tabla
        if (data.Count > 0)
        {
            var range = worksheet.Range(
                1,
                1,
                data.Count + 1,
                5
            );

            range.CreateTable();
        }

        worksheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }
    
    public void ModifyExistingReport()
    {
        using var workbook = new XLWorkbook(
            "/Users/alonsosam/Downloads/reporte_ventas.xlsx"
        );

        var worksheet = workbook.Worksheet(1);

        worksheet.Cell(1, 1).Value = "Cliente actualizado";

        workbook.Save();
    }
}