using RealERP.Application.Repositories.ProductRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.ProductRepository
{
    public class WriteProductRepository:WriteRepository<Product>, IWriteProductRepository
    {
        public WriteProductRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {
            
        }
    }
}
