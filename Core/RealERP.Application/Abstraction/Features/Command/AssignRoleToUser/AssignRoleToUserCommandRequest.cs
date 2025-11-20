using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.AssignRoleToUser
{
    public class AssignRoleToUserCommandRequest:IRequest<AssignRoleToUserCommandResponse>
    {
        public string Id { get; set; }
        public string[] Roles { get; set; }
    }
}