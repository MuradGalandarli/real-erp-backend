using Microsoft.Extensions.DependencyInjection;
using RealERP.Application.Abstraction.Service;
using RealERP.Persistence.Context;
using RealERP.Persistence.Repositories.CategoryRepository;
using RealERP.Persistence.Service;

namespace RealERP.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReadCategoeyRepository, ReadCategoryRepository>();
            services.AddScoped<IWriteCategoryRepository, WriteCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
