
using Microsoft.EntityFrameworkCore;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Exceptions;
using RealERP.Application.Repositories.BrandRepository;
using RealERP.Domain.Entities;

namespace RealERP.Persistence.Service
{

    public class BrandService : IBrandService
    {
        private readonly IWriteBrandRepository _writeBrandRepository;
        private readonly IReadBrandRepository _readBrandRepository;

        public BrandService(IReadBrandRepository readBrandRepository, IWriteBrandRepository writeBrandRepository)
        {
            _readBrandRepository = readBrandRepository;
            _writeBrandRepository = writeBrandRepository;
        }

        public async Task<bool> AddBrnadAsync(Brand brand)
        {
            bool exists = await _readBrandRepository.Table.AnyAsync(b => b.Name == brand.Name && !b.IsDeleted);
            if (exists)
                throw new BadRequestException("Brand name already exists");
            bool status = await _writeBrandRepository.AddAsync(brand);
            if (status)
                await _writeBrandRepository.SaveAsync();

            return status;
        }

        public async Task<bool> DeleteBrandAsync(int id)
        {
            Brand brand = await _readBrandRepository.GetByIdAsync(id);
            if (brand == null)
                throw new NotFoundException($"Brand with id {id} not found");

            brand.IsDeleted = true;
            foreach(Product product in brand.Products)
            {
                product.IsDeleted = true;  
            }
            await _writeBrandRepository.SaveAsync();
            return true;
        }

        public List<Brand> GetAllBrand(int page, int size)
        {
           IQueryable<Brand> brands = _readBrandRepository.GetAll().Skip((page - 1)*size).Take(size);
            return brands.ToList(); 
        }

        public async Task<Brand> GetByIdBrandAsync(int id)
        {
            Brand brand = await _readBrandRepository.GetByIdAsync(id);
            if (brand == null)
                throw new NotFoundException($"Brand with id {id} not found");
            return brand;
        }

        public async Task<bool> UpdateBrandAsync(Brand brand)
        {
            bool status = _writeBrandRepository.Update(brand);
            if (status)
            await _writeBrandRepository.SaveAsync();
            return status;
        }
    }
}
