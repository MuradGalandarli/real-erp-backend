
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Repositories.BrandRepository;
using RealERP.Domain.Entities;

namespace RealERP.Persistence.Service
{

    public class BrandService : IBrandService
    {
        private readonly IWriteBrandRepository _writeBrandRepository;

        public BrandService(IWriteBrandRepository writeBrandRepository)
        {
            _writeBrandRepository = writeBrandRepository;
        }

        public async Task<bool> AddBrnad(Brand brand)
        {
            bool status = await _writeBrandRepository.AddAsync(brand);
            if (status)
                await _writeBrandRepository.SaveAsync();

            return status;
        }
    }
}
