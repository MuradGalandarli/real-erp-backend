
using RealERP.Application.Repositories.ProductImageRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.ProductImageRepository
{
    public class WriteProductImageRepository : WriteRepository<ProductImage>, IWriteProductImageRepository
    {
        public WriteProductImageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
