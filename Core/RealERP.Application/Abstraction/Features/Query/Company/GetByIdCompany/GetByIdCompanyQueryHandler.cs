

using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Company.GetByIdCompany
{
    public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQueryRequest, GetByIdCompanyQueryResponse>
    {
        private readonly ICompanyService _companyService;

        public GetByIdCompanyQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<GetByIdCompanyQueryResponse> Handle(GetByIdCompanyQueryRequest request, CancellationToken cancellationToken)
        {
           CompanyDto company = await _companyService.GetByIdCompany(request.Id);
            return new()
            {
                Company = company,
            };
        }
    }
}
