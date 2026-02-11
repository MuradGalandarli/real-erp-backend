

using Microsoft.AspNetCore.Http;

namespace RealERP.Application.Abstraction.Service
{
    public interface IImageStorageService
    {
        Task<string> UploadAsync(IFormFile formFile);
        Task DeleteAsync(string publicId);
    }
}
