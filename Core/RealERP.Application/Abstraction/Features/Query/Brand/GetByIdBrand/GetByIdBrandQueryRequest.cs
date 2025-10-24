using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Brand.GetByIdBrand
{
    public class GetByIdBrandQueryRequest:IRequest<GetByIdBrandQueryResponse>
    {
        public int Id { get; set; }
    }
}