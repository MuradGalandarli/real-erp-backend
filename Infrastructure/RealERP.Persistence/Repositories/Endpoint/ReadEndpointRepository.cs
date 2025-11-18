

using RealERP.Application.Repositories;
using RealERP.Application.Repositories.Endpoint;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.Endpoint
{
    public class ReadEndpointRepository : ReadRepository<Domain.Entities.Endpoint>,IReadEndpointRepository
    {
        public ReadEndpointRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
