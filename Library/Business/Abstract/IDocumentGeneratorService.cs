using Entities.Dto;

namespace Business.Abstract;

public interface IDocumentGeneratorService
{
    Task<bool> CreateInvoiceTemplateAsync(string basePath, InvoiceTempateFormDto invoiceFile);
}