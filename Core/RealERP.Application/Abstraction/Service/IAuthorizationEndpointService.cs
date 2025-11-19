

namespace RealERP.Application.Abstraction.Service
{
    public interface IAuthorizationEndpointService
    {
        public Task AssignRoleEndpointAsync(string[] roles,string menu,string code,Type type);
        public Task<List<string>> GetRolesToEndpoint(string code,string menu);
    }
}
