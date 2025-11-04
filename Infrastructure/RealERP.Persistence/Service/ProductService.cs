
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
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
            if (!status)
            {
                throw new NotFoundException($"Product with id {id} not found");
            }
            await _writeProductRepository.SaveAsync();
            return status;
        }

        public List<ProductDto> GetAllProduct(int page, int size)
        {
           IQueryable<Product> products = _readProductRepository.GetAll().Skip((page - 1) * size).Take(size);
            return products.Select(p => new ProductDto()
            {
                Name = p.Name,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Id = p.Id
            }).ToList();

        }

        public async Task<ProductDto> GetByIdProduct(int id)
        {
          Product product = await _readProductRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException($"Product with id {id} not found");
            }
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
