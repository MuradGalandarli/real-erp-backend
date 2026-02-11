using CloudinaryDotNet;
using Microsoft.Extensions.DependencyInjection;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Configurations;
using RealERP.Infrastructure.Configurations;
using RealERP.Infrastructure.Service;

namespace RealERP.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IImageStorageService,ImageStorageService>();
            services.AddScoped<Cloudinary>();
        }
    }
}
