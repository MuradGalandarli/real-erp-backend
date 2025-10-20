using RealERP.Application.Repositories.BrandRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.BrandRepository
{
    public class WriteBrandRepository:WriteRepository<Brand>,IWriteBrandRepository
    {
        public WriteBrandRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext) { }

    }
}
