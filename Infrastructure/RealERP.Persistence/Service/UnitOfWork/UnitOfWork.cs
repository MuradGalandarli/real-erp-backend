using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using RealERP.Application.Abstraction.Service.UnitOfWork;
using RealERP.Application.Repositories.DepartmentRepository;
using RealERP.Application.Repositories.EmployeeRepository;
using RealERP.Domain.Entities.User;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Service.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly ApplicationDbContext _applicationDbContext;


        public UserManager<AppUser> UserManager { get; }

        public IWriteDepartmentRepository writeDepartmentRepository { get; }

        public IReadDepartmentRepository readDepartmentRepository { get; }

        public IWriteEmployeeRepository writeEmployeeRepository { get; }

        public IReadEmployeeRepository readEmployeeRepository { get; }

        public UnitOfWork(UserManager<AppUser> userManager,
            ApplicationDbContext applicationDbContext,
             IReadEmployeeRepository readEmployeeRepository,
             IWriteEmployeeRepository writeEmployeeRepository,
             IReadDepartmentRepository readDepartmentRepository,
             IWriteDepartmentRepository writeDepartmentRepository)
        {
            UserManager = userManager;
            _applicationDbContext = applicationDbContext;
            this.writeDepartmentRepository = writeDepartmentRepository;
            this.readDepartmentRepository = readDepartmentRepository;
            this.writeEmployeeRepository = writeEmployeeRepository;
            this.readEmployeeRepository = readEmployeeRepository;

        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _applicationDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
           await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
          await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
          return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
