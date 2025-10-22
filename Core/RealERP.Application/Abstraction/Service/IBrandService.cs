

using RealERP.Domain.Entities;

namespace RealERP.Application.Abstraction.Service
{
    public interface IBrandService
    {
        public Task<bool> AddBrnadAsync(Brand brand);
        public Task<bool> UpdateBrandAsync(Brand brand);
    }
}
