using Entities.Dto;

namespace ExcelService.Abstract;

public interface IExcelService
{
    List<InvoiceTemplateDto> ReadFile(string fileName, string filePath);
}