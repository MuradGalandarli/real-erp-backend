

using RealERP.Application.DTOs.Configuration;

namespace RealERP.Application.Configurations
{
    public interface IApplicationService
    {
        List<Menu> GetAuthorizeDefinitionEndpoint(Type type);
    }
}
