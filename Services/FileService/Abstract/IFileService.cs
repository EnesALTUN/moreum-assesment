using Entities.Response;
using Microsoft.AspNetCore.Http;

namespace FileService.Abstract;

public interface IFileService
{
    Task<SaveFileResponseModel> SaveFileAsync(IFormFile file, string savePath, List<string> permittedExtensions);

    Task<bool> SaveTxtFileByContentAsync(string fileName, string content, string savePath);
}