

using RealERP.Application.Repositories;
using RealERP.Application.Repositories.CompanyRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.CompanyRepository
{
    public class WriteCompanyRepository : WriteRepository<Company>, IWriteCompanyRepository
    {
        public WriteCompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
