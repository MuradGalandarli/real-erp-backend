

using RealERP.Domain.Entities;

namespace RealERP.Application.Abstraction.Service
{
    public interface IWarehouseService
    {
        public Task<bool> AddWarehouseAsync(Warehouse warehouse);
        public Task<bool> UpdateWarehouseAsync(Warehouse warehouse);
    }
}
