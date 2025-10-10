

using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.CategoryRepository
{
    public class WriteCategoryRepository:WriteRepository<Category>,IWriteCategoryRepository
    {
        public WriteCategoryRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
