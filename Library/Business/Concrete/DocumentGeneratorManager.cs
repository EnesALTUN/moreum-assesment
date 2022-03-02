using Business.Abstract;
using Entities.Dto;
using Entities.Response;
using ExcelService.Abstract;
using FileService.Abstract;
using TemplateService.Abstract;

namespace Business.Concrete;

public class DocumentGeneratorManager : IDocumentGeneratorService
{
    private readonly IExcelService _excelService;
    private readonly ITemplateService _templateService;
    private readonly IFileService _fileService;

    public DocumentGeneratorManager(
        IExcelService excelService,
        ITemplateService templateService,
        IFileService fileService)
    {
        _excelService = excelService;
        _templateService = templateService;
        _fileService = fileService;
    }

    public async Task<bool> CreateInvoiceTemplateAsync(string basePath, InvoiceTempateFormDto invoiceFile)
    {
        if (invoiceFile.CsvFile is null || invoiceFile.TemplateFile is null)
            return false;

        SaveFileResponseModel CsvSaveFileResponse = await _fileService.SaveFileAsync(invoiceFile.CsvFile, $"{basePath}\\Data", new List<string> { ".csv" });
        SaveFileResponseModel TxtSaveFileResponse = await _fileService.SaveFileAsync(invoiceFile.TemplateFile, $"{basePath}\\Templates", new List<string> { ".txt" });

        if (CsvSaveFileResponse.IsSuccess && TxtSaveFileResponse.IsSuccess)
        {
            List<InvoiceTemplateDto> invoices = _excelService.ReadFile(CsvSaveFileResponse.FileName, $"{basePath}\\Data");

            bool isSuccessCreateTemplate = await _templateService.CreateTemplateAsync(invoices, TxtSaveFileResponse.FileName, $"{basePath}\\Templates");

            if (!isSuccessCreateTemplate)
                return false;

            return true;
        }

        return false;
    }
}