using Microsoft.EntityFrameworkCore;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs.ResponseDto;
using RealERP.Application.Exceptions;
using RealERP.Application.Repositories.WarehouseRepository;
using RealERP.Domain.Entities;

namespace RealERP.Persistence.Service
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWriteWarehouseRepository _warehouseRepository;
        private readonly IReadWarehouseRepository _readWarehouseRepository;

        public WarehouseService(IWriteWarehouseRepository warehouseRepository, IReadWarehouseRepository readWarehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
            _readWarehouseRepository = readWarehouseRepository;
        }

        public async Task<bool> AddWarehouseAsync(Warehouse warehouse)
        {
            bool status = await _warehouseRepository.AddAsync(warehouse);
            await _warehouseRepository.SaveAsync(); 
            return status;
        }

        public async Task<bool> DeleteWarehouseAsync(int id)
        {
           bool status = _warehouseRepository.Delete(id);
           if(!status)
            {
                throw new NotFoundException($"Warehouse with id {id} not found");
            }
            await _warehouseRepository.SaveAsync();
            return status;
        }

        public List<WarehouseResponseDto> GetAllWarehouse(int page, int size)
        {
           IQueryable<Warehouse> warehouses = _readWarehouseRepository.GetAll().Skip((page - 1)*size).Take(size);
            return warehouses.Select(w => new WarehouseResponseDto
            {
                Description = w.Description,
                Id = w.Id,
                Location = w.Location,
                Name = w.Name,
            }).ToList();
        }

        public async Task<WarehouseResponseDto> GetByIdWarehouseAsync(int id)
        {
            Warehouse warehouse = await _readWarehouseRepository.GetByIdAsync(id);
            if (warehouse == null)
            {
               throw new NotFoundException($"Warehouse with id {id} not found");
            }
            return new()
            {
                Description = warehouse.Description,
                Id = warehouse.Id,
                Location = warehouse.Location,
                Name = warehouse.Name,
            };
        }

        public async Task<bool> UpdateWarehouseAsync(Warehouse warehouse)
        {
            bool status = _warehouseRepository.Update(warehouse);
          
            await _warehouseRepository.SaveAsync();
            return status;
        }
    }
}
