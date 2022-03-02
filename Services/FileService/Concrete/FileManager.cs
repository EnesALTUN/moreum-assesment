using Entities.Response;
using FileService.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text;

namespace FileService.Concrete;

public class FileManager : IFileService
{
    private readonly ILogger<FileManager> _logger;

    public FileManager(ILogger<FileManager> logger)
    {
        _logger = logger;
    }

    public async Task<SaveFileResponseModel> SaveFileAsync(IFormFile file, string savePath, List<string> permittedExtensions)
    {
        try
        {
            if (file is null)
                throw new Exception("Dosya gönderilmedi.");

            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            SaveFileResponseModel response = new()
            {
                FileName = $"{Guid.NewGuid()}{fileExtension}"
            };

            if (permittedExtensions.Contains(fileExtension))
            {
                if (!Directory.Exists(savePath))
                    Directory.CreateDirectory(savePath);

                using (var stream = new FileStream(Path.Combine(savePath, response.FileName), FileMode.Create))
                    await file.CopyToAsync(stream);

                response.IsSuccess = true;
                return response;
            }
            else
                return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new SaveFileResponseModel();
        }
    }

    public async Task<bool> SaveTxtFileByContentAsync(string fileName, string content, string savePath)
    {
        try
        {
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            await File.WriteAllTextAsync($"{savePath}\\{fileName}.txt", content, Encoding.UTF8);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return false;
        }
    }
}