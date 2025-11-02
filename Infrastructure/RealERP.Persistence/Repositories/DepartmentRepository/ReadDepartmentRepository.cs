using RealERP.Application.Repositories.DepartmentRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.DepartmentRepository
{
    public class ReadDepartmentRepository : ReadRepository<Department>,IReadDepartmentRepository
    {
        public ReadDepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
