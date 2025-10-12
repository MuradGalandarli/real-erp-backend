

using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.CategoryRepository
{
    public class ReadCategoryRepository : ReadRepository<Category>, IReadCategoryRepository
    {
        public ReadCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
