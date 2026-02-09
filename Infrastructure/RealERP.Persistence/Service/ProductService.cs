
using Microsoft.EntityFrameworkCore;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
using RealERP.Application.Repositories.ProductRepository;
using RealERP.Domain.Entities;
using System.Numerics;

namespace RealERP.Persistence.Service
{
    public class ProductService : IProductService
    {
        private readonly IWriteProductRepository _writeProductRepository;
        private readonly IReadProductRepository _readProductRepository;


        public ProductService(IWriteProductRepository writeProductRepository, IReadProductRepository readProductRepository)
        {
            _writeProductRepository = writeProductRepository;
            _readProductRepository = readProductRepository;
        }
        //        Product price <= 0 ola bilməz

        //Product yalnız active Brand və Category ilə yaradıla bilər

        //Product name Company daxilində unikal olsun

        //Product soft delete olunduqda stock əməliyyatları dayansın
        //Send your CV and portfolio to hr @startechco.az e-mail address. Please include “Backend Developer (C#)” in the email subject line.
        public async Task<bool> AddProductAsync(ProductDto productDto)
        {
            bool exists = await _readProductRepository.Table.
                AnyAsync(p => p.Name == productDto.Name &&
                p.CompanyId == productDto.CompanyId &&
                !p.IsDeleted);
            if (exists)
                throw new BadRequestException("This add-on is now available.");

            bool status = await _writeProductRepository.AddAsync(new()
            {
                Name = productDto.Name,
                BrandId = productDto.BrandId,
                CategoryId = productDto.CategoryId,
                Description = productDto.Description,
                CompanyId = productDto.CompanyId,
            });
            if (status)
               await _writeProductRepository.SaveAsync();
            return status;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
           Product product = await _readProductRepository.GetByIdAsync(id);
            if (product == null)
                throw new NotFoundException($"Product with id {id} not found");

            product.IsDeleted = true;
            await _writeProductRepository.SaveAsync();
            return true;
        }

        public List<ProductDto> GetAllProduct(int page, int size)
        {
           IQueryable<Product> products = _readProductRepository.GetAll().Skip((page - 1) * size).Take(size);
            if(products == null)
                return new List<ProductDto>();
            return products.Select(p => new ProductDto()
            {
                Name = p.Name,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Id = p.Id,
                CompanyId = p.CompanyId
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
                CompanyId = product.CompanyId
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
