

using Microsoft.AspNetCore.Identity;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;
using RealERP.Domain.Entities.Identity;

namespace RealERP.Persistence.Service
{
    public class RoleService : IRoleServices
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }        

        public async Task<bool> AddRole(RoleDto role)
        {
           IdentityResult identityResult = await _roleManager.CreateAsync(new() {Id = Guid.NewGuid().ToString(), Name = role.Name });
            return identityResult.Succeeded;
        }

        public async Task<bool> UpdateRole(RoleDto role)
        {
            var existingRole = await _roleManager.FindByIdAsync(role.id);

            if (existingRole == null)
                return false;

            existingRole.Name = role.Name;
            existingRole.NormalizedName = role.Name.ToUpper();

            IdentityResult identityResult = await _roleManager.UpdateAsync(existingRole);

            return identityResult.Succeeded;
        }

    }
}
