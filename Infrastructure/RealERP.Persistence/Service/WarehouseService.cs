

using Microsoft.EntityFrameworkCore.ChangeTracking;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Repositories.WarehouseRepository;
using RealERP.Domain.Entities;

namespace RealERP.Persistence.Service
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWriteWarehouseRepository _warehouseRepository;

        public WarehouseService(IWriteWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<bool> AddWarehouseAsync(Warehouse warehouse)
        {
            bool status = await _warehouseRepository.AddAsync(warehouse);
            await _warehouseRepository.SaveAsync(); 
            return status;
        }

        public async Task<bool> UpdateWarehouseAsync(Warehouse warehouse)
        {
            bool status = _warehouseRepository.Update(warehouse);
          
            await _warehouseRepository.SaveAsync();
            return status;
        }
    }
}
