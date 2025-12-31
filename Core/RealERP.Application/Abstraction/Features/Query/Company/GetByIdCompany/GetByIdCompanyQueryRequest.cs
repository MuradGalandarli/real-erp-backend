using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Company.GetByIdCompany
{
    public class GetByIdCompanyQueryRequest: IRequest<GetByIdCompanyQueryResponse>
    {
        public int Id { get; set; }
    }
}