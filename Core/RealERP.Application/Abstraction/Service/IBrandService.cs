

using RealERP.Domain.Entities;

namespace RealERP.Application.Abstraction.Service
{
    public interface IBrandService
    {
        public Task<bool> AddBrnadAsync(Brand brand);
        public Task<bool> UpdateBrandAsync(Brand brand);
        public Task<bool> DeleteBrandAsync(int id);
        public Task<Brand> GetByIdBrandAsync(int id);
        public List<Brand> GetAllBrand(int page, int size);
    }
}
