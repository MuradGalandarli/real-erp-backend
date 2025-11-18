using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.AuthorizationEndpoint.AssignRoleEndpoint
{
    public class AssignRoleEndpointCommandRequest:IRequest<AssignRoleEndpointCommandResponse>
    {
        public string[] Roles { get; set; }
        public string Code { get; set; }
        public string Menu { get; set; }
        public Type Type { get; set; }

    }
}