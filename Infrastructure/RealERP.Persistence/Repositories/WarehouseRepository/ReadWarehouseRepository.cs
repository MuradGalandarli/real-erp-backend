

using RealERP.Application.Repositories.WarehouseRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.WarehouseRepository
{
    public class ReadWarehouseRepository:ReadRepository<Warehouse>,IReadWarehouseRepository
    {
        public ReadWarehouseRepository(ApplicationDbContext context):base(context) { }
      
    }
}
