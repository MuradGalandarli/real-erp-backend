

using RealERP.Application.Repositories.ProductImageRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.ProductImageRepository
{
    public class ReadProductImageRepository : ReadRepository<ProductImage>, IReadProductImageRepository
    {
        public ReadProductImageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
