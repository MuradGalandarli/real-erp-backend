
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Service
{
    public interface IRoleServices
    {
        public Task<bool> AddRole(RoleDto role);
        public Task<bool> UpdateRole(RoleDto role);
    }
}
