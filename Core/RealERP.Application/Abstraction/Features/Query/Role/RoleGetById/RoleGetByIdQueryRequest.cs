using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Role.RoleGetById
{
    public class RoleGetByIdQueryRequest:IRequest<RoleGetByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}