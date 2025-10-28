using RealERP.Application.DTOs;
using RealERP.Domain.Entities;

namespace RealERP.Application.Abstraction.Service
{
    public interface IWarehouseService
    {
        public Task<bool> AddWarehouseAsync(Warehouse warehouse);
        public Task<bool> UpdateWarehouseAsync(Warehouse warehouse);
        public Task<WarehouseDto> GetByIdWarehouseAsync(int id);
        public Task<bool> DeleteWarehouseAsync(int id);
        public List<WarehouseDto> GetAllWarehouse(int page,int size);
    }
}
