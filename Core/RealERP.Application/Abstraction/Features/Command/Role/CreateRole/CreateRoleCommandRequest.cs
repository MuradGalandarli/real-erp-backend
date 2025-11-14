using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Role.CreateRole
{
    public class CreateRoleCommandRequest:IRequest<CreateRoleCommandResponse>
    {
        public string Name { get; set; }
    }
}