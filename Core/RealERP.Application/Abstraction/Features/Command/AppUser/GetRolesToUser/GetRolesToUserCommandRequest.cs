using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.AppUser.GetRolesToUser
{
    public class GetRolesToUserCommandRequest:IRequest<GetRolesToUserCommandResponse>
    {
        public string UserId { get; set; }
    }
}