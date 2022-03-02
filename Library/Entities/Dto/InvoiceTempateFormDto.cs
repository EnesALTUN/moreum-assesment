using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dto;

public class InvoiceTempateFormDto
{
    [Required(ErrorMessage = "CSV dosyası gereklidir.")]
    public IFormFile? CsvFile { get; set; }

    [Required(ErrorMessage = "Template dosyası gereklidir.")]
    public IFormFile? TemplateFile { get; set; }
}