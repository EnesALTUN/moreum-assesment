namespace Entities.Response;

public class SaveFileResponseModel
{
    public bool IsSuccess { get; set; } = false;

    public string? FileName { get; set; }
}