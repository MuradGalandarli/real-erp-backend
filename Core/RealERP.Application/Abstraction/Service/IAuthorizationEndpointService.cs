

using System.Globalization;

namespace RealERP.Application.Abstraction.Service
{
    public interface IAuthorizationEndpointService
    {
        public Task AssignRoleEndpointAsync(string[] roles,string menu,string code,Type type);
    }
}
