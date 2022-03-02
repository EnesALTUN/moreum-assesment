using CsvHelper;
using CsvHelper.Configuration;
using Entities.Dto;
using ExcelService.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace ExcelService.Concrete;

public class ExcelManager : IExcelService
{
    private readonly CsvConfiguration _csvConfiguration;
    private readonly ILogger<ExcelManager> _logger;

    public ExcelManager(ILogger<ExcelManager> logger)
    {
        _csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            HasHeaderRecord = false,
            Delimiter = ";",
        };
        _logger = logger;
    }

    public List<InvoiceTemplateDto> ReadFile(string fileName, string filePath)
    {
        try
        {
            List<InvoiceTemplateDto> invoices = new();

            using var streamReader = File.OpenText($"{filePath}\\{fileName}");
            using var csvReader = new CsvReader(streamReader, _csvConfiguration);

            while (csvReader.Read())
            {
                bool isGetTotal = int.TryParse(csvReader.GetField(3).Trim(), out int Total);

                if (isGetTotal)
                {
                    InvoiceTemplateDto invoice = new()
                    {
                        InvoiceNo = csvReader.GetField(0).Trim(),
                        Name = csvReader.GetField(1).Trim(),
                        Surname = csvReader.GetField(2).Trim(),
                        Total = Total
                    };

                    invoices.Add(invoice);
                }
            }

            return invoices;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Excel okunurken hata oluştu.");
        }
    }
}