

using RealERP.Application.Repositories.WarehouseRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.WarehouseRepository
{
    public class WriteWarehouseRepository : WriteRepository<Warehouse>, IWriteWarehouseRepository
    {
        public WriteWarehouseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
