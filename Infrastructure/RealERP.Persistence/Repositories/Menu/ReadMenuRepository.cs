using RealERP.Application.Repositories.Menu;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.Menu
{
    public class ReadMenuRepository : ReadRepository<Domain.Entities.Menu>,IReadMenuRepository
    {
        public ReadMenuRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
