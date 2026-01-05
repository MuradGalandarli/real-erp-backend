

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
using RealERP.Domain.Entities.Identity;
using System.Data;

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

        public async Task<bool> DeleteRole(string id)
        {
            AppRole role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null)
            {
                throw new NotFoundException($"There in not {id} role");
            }
           await _roleManager.DeleteAsync(role);
            return true;
        }

        public async Task<List<RoleDto>> GetAllRole(int page, int size)
        {
            var roles = await _roleManager.Roles
       .Skip((page - 1) * size)
       .Take(size)
       .Select(r => new RoleDto
       {
           id = r.Id,
           Name = r.Name
       })
       .ToListAsync();

            return roles;
        }

        public async Task<RoleDto> GetByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
                throw new NotFoundException($"Role with id {id} not found");

            return new()
            {
                id = role.Id,
                Name = role.Name
            };
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
