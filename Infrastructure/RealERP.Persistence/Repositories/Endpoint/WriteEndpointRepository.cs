

using RealERP.Application.Repositories.Endpoint;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories.Endpoint
{
    public class WriteEndpointRepository : WriteRepository<Domain.Entities.Endpoint>,IWriteEndpointRepository
    {
        public WriteEndpointRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
