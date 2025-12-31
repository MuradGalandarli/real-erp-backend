using MediatR;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Company.GetByIdCompany
{
    public class GetByIdCompanyQueryResponse
    {
        public CompanyDto Company { get; set; }
    }
}