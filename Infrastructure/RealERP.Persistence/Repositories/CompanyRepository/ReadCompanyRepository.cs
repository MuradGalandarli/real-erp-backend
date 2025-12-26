

using RealERP.Application.Repositories.CompanyRepository;
using RealERP.Domain.Entities;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.CompanyRepository
{
    public class ReadCompanyRepository : ReadRepository<Company>,IReadCompanyRepository
    {
        public ReadCompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
