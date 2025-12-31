

using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Company.GetByIdCompany
{
    public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQueryResponse, GetByIdCompanyQueryRequest>
        >
    {
        public Task<GetByIdCompanyQueryRequest> Handle(GetByIdCompanyQueryResponse request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
