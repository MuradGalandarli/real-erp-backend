

using RealERP.Application.Repositories.EmployeeRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.EmployeeRepository
{
    public class WriteEmployeeRepository : WriteRepository<Employee>, IWriteEmployeeRepository
    {
        public WriteEmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
