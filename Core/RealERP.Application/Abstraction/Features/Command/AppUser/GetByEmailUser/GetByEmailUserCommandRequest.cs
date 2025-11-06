using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.AppUser.GetByEmailUser
{
    public class GetByEmailUserCommandRequest:IRequest<GetByEmailUserCommandResponse>
    {
        public string Email { get; set; }
    }
}