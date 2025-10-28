
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;
using RealERP.Application.Repositories.ProductRepository;
using RealERP.Domain.Entities;

namespace RealERP.Persistence.Service
{
    public class ProductService : IProductService
    {
        private readonly IWriteProductRepository _writeProductRepository;
        private readonly IReadProductRepository _readProductRepository;

        public ProductService(IWriteProductRepository writeProductRepository)
        {
            _writeProductRepository = writeProductRepository;
        }

        public async Task<bool> AddProductAsync(ProductDto productDto)
        {
            bool status = await _writeProductRepository.AddAsync(new()
            {
                Name = productDto.Name,
                BrandId = productDto.BrandId,
                CategoryId = productDto.CategoryId,
                Description = productDto.Description,
            });
            if (status)
               await _writeProductRepository.SaveAsync();
            return status;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
           bool status = _writeProductRepository.Delete(id);
            if (status)
                await _writeProductRepository.SaveAsync();
            return status;
        }

        public async Task<ProductDto> GetByIdProduct(int id)
        {
          Product product = await _readProductRepository.GetByIdAsync(id);
            return new()
            {
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Id = product.Id,
                Name = product.Name,
            };
        }

        public async Task<bool> UpdateProductAsync(ProductDto productDto)
        {
           bool status = _writeProductRepository.Update(new()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                BrandId = productDto.BrandId,
                CategoryId = productDto.CategoryId,
                Description = productDto.Description,
                
            });
            if(status)
           await _writeProductRepository.SaveAsync();

            return status;
        }
    }
}
