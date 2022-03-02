namespace Entities.Dto;

public class InvoiceTemplateDto
{
    public string? InvoiceNo { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime Date = DateTime.Now;

    public int Total { get; set; }
}