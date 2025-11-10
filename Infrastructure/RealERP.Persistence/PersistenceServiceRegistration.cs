using Microsoft.Extensions.DependencyInjection;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Repositories.BrandRepository;
using RealERP.Application.Repositories.DepartmentRepository;
using RealERP.Application.Repositories.EmployeeRepository;
using RealERP.Application.Repositories.ProductRepository;
using RealERP.Application.Repositories.WarehouseRepository;
using RealERP.Persistence.Context;
using RealERP.Persistence.Repositories.BrandRepository;
using RealERP.Persistence.Repositories.CategoryRepository;
using RealERP.Persistence.Repositories.DepartmentRepository;
using RealERP.Persistence.Repositories.EmployeeRepository;
using RealERP.Persistence.Repositories.ProductRepository;
using RealERP.Persistence.Repositories.WarehouseRepository;
using RealERP.Persistence.Service;

namespace RealERP.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReadCategoryRepository, ReadCategoryRepository>();
            services.AddScoped<IWriteCategoryRepository, WriteCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IReadWarehouseRepository, ReadWarehouseRepository>();
            services.AddScoped<IWriteWarehouseRepository, WriteWarehouseRepository>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IReadBrandRepository, ReadBrandRepository>();
            services.AddScoped<IWriteBrandRepository, WriteBrandRepository>();
            services.AddScoped<IWriteProductRepository, WriteProductRepository>();
            services.AddScoped<IReadProductRepository, ReadProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IReadDepartmentRepository, ReadDepartmentRepository>();
            services.AddScoped<IWriteDepartmentRepository, WriteDepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IReadEmployeeRepository, ReadEmployeeRepository>();
            services.AddScoped<IWriteEmployeeRepository, WriteEmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

        }
    }
}
