

using RealERP.Application.Repositories;
using RealERP.Application.Repositories.ProductRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.ProductRepository
{
    public class ReadProductRepository : ReadRepository<Product>, IReadProductRepository
    {
        public ReadProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
