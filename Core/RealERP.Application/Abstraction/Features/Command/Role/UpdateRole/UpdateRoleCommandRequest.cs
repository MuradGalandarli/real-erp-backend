using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Role.UpdateRole
{
    public class UpdateRoleCommandRequest:IRequest<UpdateRoleCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}