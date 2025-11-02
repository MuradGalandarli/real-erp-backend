using RealERP.Application.Repositories.DepartmentRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.DepartmentRepository
{
    public class WriteDepartmentRepository : WriteRepository<Department>, IWriteDepartmentRepository
    {
        public WriteDepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
