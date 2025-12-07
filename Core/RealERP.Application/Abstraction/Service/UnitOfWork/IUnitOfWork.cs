

using Microsoft.AspNetCore.Identity;
using RealERP.Application.Repositories.DepartmentRepository;
using RealERP.Application.Repositories.EmployeeRepository;
using RealERP.Domain.Entities;
using RealERP.Domain.Entities.User;

namespace RealERP.Application.Abstraction.Service.UnitOfWork
{
    public interface IUnitOfWork
    {
        UserManager<AppUser> UserManager { get; }
        IWriteDepartmentRepository writeDepartmentRepository { get; }
        IReadDepartmentRepository readDepartmentRepository { get; }
        IWriteEmployeeRepository writeEmployeeRepository { get; }
        IReadEmployeeRepository readEmployeeRepository { get; }

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();

        Task<int> SaveChangesAsync();
    }
}
