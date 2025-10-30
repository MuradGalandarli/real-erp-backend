using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Product.GetAllProduct
{
    public class GetAllProductQueryRequest:IRequest<List<GetAllProductQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}