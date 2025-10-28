
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs.RequestDto;
using RealERP.Application.Repositories.ProductRepository;

namespace RealERP.Persistence.Service
{
    public class ProductService : IProductService
    {
        private readonly IWriteProductRepository _writeProductRepository;

        public ProductService(IWriteProductRepository writeProductRepository)
        {
            _writeProductRepository = writeProductRepository;
        }

        public async Task<bool> AddProductAsync(ProductRequestDto productRequestDto)
        {
            bool status = await _writeProductRepository.AddAsync(new()
            {
                Name = productRequestDto.Name,
                BrandId = productRequestDto.BrandId,
                CategoryId = productRequestDto.CategoryId,
                Description = productRequestDto.Description,
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

        public async Task<bool> UpdateProductAsync(ProductRequestDto productRequestDto)
        {
           bool status = _writeProductRepository.Update(new()
            {
                Id = productRequestDto.Id,
                Name = productRequestDto.Name,
                BrandId = productRequestDto.BrandId,
                CategoryId = productRequestDto.CategoryId,
                Description = productRequestDto.Description,
                
            });
            if(status)
           await _writeProductRepository.SaveAsync();

            return status;
        }
    }
}
