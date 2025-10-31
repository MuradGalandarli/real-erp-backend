using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.AppUser
{
    public class GetAllUserQueryRequest:IRequest<List<GetAllUserQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}