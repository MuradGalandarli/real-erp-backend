using RealERP.Application.DTOs.ResponseDto;
using RealERP.Domain.Entities;

namespace RealERP.Application.Abstraction.Service
{
    public interface IWarehouseService
    {
        public Task<bool> AddWarehouseAsync(Warehouse warehouse);
        public Task<bool> UpdateWarehouseAsync(Warehouse warehouse);
        public Task<WarehouseResponseDto> GetByIdWarehouseAsync(int id);
        public Task<bool> DeleteWarehouseAsync(int id);
    }
}
