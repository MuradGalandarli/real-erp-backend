using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Brand.GetAllBrand
{
    public class GetAllBrandQueryRequest:IRequest<List<GetAllBrandQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}