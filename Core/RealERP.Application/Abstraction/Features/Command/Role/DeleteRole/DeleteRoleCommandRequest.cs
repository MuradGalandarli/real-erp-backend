using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Role.DeleteRole
{
    public class DeleteRoleCommandRequest:IRequest<DeleteRoleCommandResponse>
    {
        public string Id { get; set; }
    }
}