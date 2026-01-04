using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Role.GetAllRole
{
    public class GetAllRoleQueryRequest:IRequest<List<GetAllRoleQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}