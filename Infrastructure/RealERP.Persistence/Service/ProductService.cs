using Microsoft.EntityFrameworkCore;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Abstraction.Service.UnitOfWork;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
using RealERP.Application.Repositories.ProductRepository;
using RealERP.Domain.Entities;
using System.Security.Principal;

namespace RealERP.Persistence.Service
{
    public class ProductService : IProductService
    {
        private readonly IWriteProductRepository _writeProductRepository;
        private readonly IReadProductRepository _readProductRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IWriteProductRepository writeProductRepository, IReadProductRepository readProductRepository, IUnitOfWork unitOfWork)
        {
            _writeProductRepository = writeProductRepository;
            _readProductRepository = readProductRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddProductAsync(ProductDto productDto)
        {
            bool exists = await _readProductRepository.Table.
                AnyAsync(p => p.Name == productDto.Name &&
                p.CompanyId == productDto.CompanyId &&
                !p.IsDeleted);
            if (exists)
                throw new BadRequestException("This add-on is now available.");


            Product product = new Product()
            {
                Name = productDto.Name,
                BrandId = productDto.BrandId,
                CategoryId = productDto.CategoryId,
                Description = productDto.Description,
                CompanyId = productDto.CompanyId,
            };

            bool status = await _writeProductRepository.AddAsync(product);

            if (status)
                await _writeProductRepository.SaveAsync();

            foreach (var image in productDto.Images)
            {
                var result = await _unitOfWork.imageStorageService.UploadAsync(image);
                await _unitOfWork.writeProductImageRepository.AddAsync(new()
                {
                    ImageUrl = result.Item1,
                    IsDeleted = false,
                    ProductId =product.Id ,
                    PublicId = result.Item2
                    
                });
               
            }
            await _unitOfWork.SaveChangesAsync();
           
            return status;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            Product? product = await _readProductRepository.GetWhere(p => p.Id == id).
                 Include(i => i.ProductImages).FirstOrDefaultAsync();
            if (product == null)
                throw new NotFoundException($"Product with id {id} not found");

            product.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();

            foreach(var image in product.ProductImages)
            {
                bool status = await _unitOfWork.imageStorageService.DeleteAsync(image.PublicId);
                if (status)
                    image.IsDeleted = true;
            }
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public List<ProductRequestDto> GetAllProduct(int page, int size)
        {
            IQueryable<Product> products = _readProductRepository.GetAll()
                 .Include(i => i.ProductImages)
                .Skip((page - 1) * size).Take(size);

            if (products == null)
               return new();

           return products.Select(p => new ProductRequestDto()
            {
               Name = p.Name,
               BrandId = p.BrandId,
               CategoryId = p.CategoryId,
               Description = p.Description,
               Id = p.Id,
               CompanyId = p.CompanyId,
               ProductImages = p.ProductImages.ToList(),
           }).ToList();
            
        }
        
        public async Task<ProductRequestDto> GetByIdProduct(int id)
        {
          Product? product = await _readProductRepository.
                GetWhere(x=>x.Id == id).
                Include(i => i.ProductImages).
                FirstOrDefaultAsync();

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
                CompanyId = product.CompanyId,
                ProductImages = product.ProductImages.ToList(),
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
                CompanyId= productDto.CompanyId,
                
            });
            if(status)
           await _writeProductRepository.SaveAsync();

            return status;
        }
    }
}
