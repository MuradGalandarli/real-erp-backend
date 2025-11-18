

using RealERP.Application.Repositories.Menu;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.Menu
{
    public class WriteMenuRepository : WriteRepository<Domain.Entities.Menu>, IWriteMenuRepository
    {
        public WriteMenuRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
