
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Service   
{
    public interface IRoleServices
    {
        public Task<bool> AddRole(RoleDto role);
        public Task<bool> UpdateRole(RoleDto role);
        public Task<bool> DeleteRole(string id);
        public Task<RoleDto> GetByIdAsync(string id);
        public Task<List<RoleDto>> GetAllRole(int page, int size);
    }
}
