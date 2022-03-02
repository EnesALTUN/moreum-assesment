using Entities.Dto;
using FileService.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TemplateService.Abstract;

namespace TemplateService.Concrete;

public class TemplateManager : ITemplateService
{
    private readonly ILogger<TemplateManager> _logger;
    private readonly IFileService _fileService;

    public TemplateManager(ILogger<TemplateManager> logger, IFileService fileService)
    {
        _logger = logger;
        _fileService = fileService;
    }

    public async Task<bool> CreateTemplateAsync(List<InvoiceTemplateDto> invoices, string fileName, string filePath)
    {
        try
        {
            string templateStr = File.ReadAllText($"{filePath}\\{fileName}");

            foreach (var invoice in invoices)
            {
                if (string.IsNullOrEmpty(invoice.InvoiceNo))
                {
                    _logger.LogError("Fatura numarası boş gönderildi");
                    continue;
                }

                string templateTmp = templateStr;

                templateTmp = templateTmp.Replace("{TARIH}", DateTime.Now.ToString("dd.MM.yyyy"));
                templateTmp = templateTmp.Replace("{AD}", invoice.Name);
                templateTmp = templateTmp.Replace("{SOYAD}", invoice.Surname);
                templateTmp = templateTmp.Replace("{FATURANO}", invoice.InvoiceNo);
                templateTmp = templateTmp.Replace("{TUTAR}", invoice.Total.ToString());

                bool isSuccessTxtFile = await _fileService.SaveTxtFileByContentAsync(invoice.InvoiceNo, templateTmp, "wwwroot\\Invoices");

                if (!isSuccessTxtFile)
                    _logger.LogError($"{invoice.InvoiceNo} nolu template dosyası oluşturulamadı.");
            }
            return true;
        }
        catch (Exception)
        {
            _logger.LogError("Template dosyası oluşturulurken hata!");
            return false;
        }
    }
}