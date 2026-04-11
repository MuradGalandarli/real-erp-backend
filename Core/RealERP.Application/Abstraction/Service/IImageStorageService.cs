

using Microsoft.AspNetCore.Http;

namespace RealERP.Application.Abstraction.Service
{
    public interface IImageStorageService
    {
        Task<(string imageUrl, string publicId)> UploadAsync(IFormFile formFile);
        Task<bool> DeleteAsync(string publicId);
    }
}
