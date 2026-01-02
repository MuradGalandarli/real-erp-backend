using MediatR;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Company.GetAllCompany
{
    public class GetAllCompanyQueryRequest:IRequest<GetAllCompanyQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}