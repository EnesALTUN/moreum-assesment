using Entities.Dto;

namespace TemplateService.Abstract;

public interface ITemplateService
{
    Task<bool> CreateTemplateAsync(List<InvoiceTemplateDto> invoices, string fileName, string filePath);
}