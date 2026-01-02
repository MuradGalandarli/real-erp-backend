

using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Company.GetAllCompany
{
    public class GetAllCompanyQueryHandler : IRequestHandler< GetAllCompanyQueryRequest, GetAllCompanyQueryResponse>
    {
        private readonly ICompanyService _companyService;

        public GetAllCompanyQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<GetAllCompanyQueryResponse> Handle(GetAllCompanyQueryRequest request, CancellationToken cancellationToken)
        {
           List<CompanyDto> companies = await _companyService.GetAllCompany(request.Page, request.Size);
            return new()
            {
                CompanyDto = companies
            };
        }
    }
}
