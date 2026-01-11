using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Service
{
    public interface IUserService
    {
        public Task<Response> CreateAsync(RegisterDto register,string role);
        public Task<List<UserDto>> GetAllUser(int Page, int Size);
        public Task<bool> UpdateUserAsync(UserDto user);
        public Task<UserDto> GetByEmailUserAsync(string email);
        public Task<bool> DeleteUserByEmailAsync(string email);
        public Task AssignRoleToUserAsync(string id, string[] roles);
        public Task<string[]>GetRolesToUserAsync(string userIdOrName);
        public Task<bool> HasRolePermissionToEndpointAsync(string name, string code);

    }
}
