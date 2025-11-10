
using RealERP.Application.Repositories.EmployeeRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.EmployeeRepository
{
    public class ReadEmployeeRepository:ReadRepository<Employee>,IReadEmployeeRepository
    {
        public ReadEmployeeRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {
            
        }
    }
}
