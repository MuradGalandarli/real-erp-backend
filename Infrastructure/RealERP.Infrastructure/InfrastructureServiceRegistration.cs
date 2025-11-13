using Microsoft.Extensions.DependencyInjection;
using RealERP.Application.Configurations;
using RealERP.Infrastructure.Configurations;

namespace RealERP.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
