
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RealERP.Application.Abstraction.Service;
using System.Runtime.InteropServices;

namespace RealERP.Infrastructure.Service
{
    public class ImageStorageService : IImageStorageService
    {
        private readonly Cloudinary _cloudinary;

        public ImageStorageService(IConfiguration configuration)
        {
            var account = new Account(
                configuration["Cloudinary:CloudName"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]
            );

            _cloudinary = new Cloudinary(account);
        }

        public Task DeleteAsync(string publicId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadAsync(IFormFile formFile)
        {

            if (formFile == null || formFile.Length == 0)
                throw new Exception("There is not image");

            using var stream = formFile.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(formFile.FileName,stream),
                Folder = "products",
                Overwrite = false
            };

            var result = await _cloudinary.UploadAsync(uploadParams);

            return result.SecureUrl.ToString();
        }
    }
}
