

using Microsoft.AspNetCore.Identity;
using RealERP.Application.Repositories.CompanyRepository;
using RealERP.Application.Repositories.DepartmentRepository;
using RealERP.Application.Repositories.EmployeeRepository;
using RealERP.Application.Repositories.ProductImageRepository;
using RealERP.Application.Repositories.ProductRepository;
using RealERP.Domain.Entities;
using RealERP.Domain.Entities.User;
using RealERP.Persistence.Repositories.CategoryRepository;

namespace RealERP.Application.Abstraction.Service.UnitOfWork
{
    public interface IUnitOfWork
    {
        UserManager<AppUser> UserManager { get; }
        IWriteDepartmentRepository writeDepartmentRepository { get; }
        IReadDepartmentRepository readDepartmentRepository { get; }
        IWriteEmployeeRepository writeEmployeeRepository { get; }
        IReadEmployeeRepository readEmployeeRepository { get; }
        IWriteCategoryRepository categoryWriteRepository { get; }
        IReadCategoryRepository categoryReadRepository { get; }
        IReadProductRepository readProductRepository { get; }
        IWriteProductRepository writeProductRepository { get; }
        IWriteCompanyRepository writeCompanyRepository { get; }
        IReadCompanyRepository readCompanyRepository { get; }
        IReadProductImageRepository readProductImageRepository { get; }
        IWriteProductImageRepository writeProductImageRepository { get; }
        IImageStorageService imageStorageService { get; }

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();

        Task<int> SaveChangesAsync();
    }
}
