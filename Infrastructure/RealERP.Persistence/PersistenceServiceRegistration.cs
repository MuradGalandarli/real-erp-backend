using Microsoft.Extensions.DependencyInjection;
using RealERP.Application.Abstraction.Service;
using RealERP.Persistence.Context;
using RealERP.Persistence.Service;

namespace RealERP.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
