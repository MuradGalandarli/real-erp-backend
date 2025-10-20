

using RealERP.Application.Repositories.BrandRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.BrandRepository
{
    public class ReadBrandRepository : ReadRepository<Brand>, IReadBrandRepository
    {
        public ReadBrandRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
