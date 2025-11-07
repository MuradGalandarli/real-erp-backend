using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.AppUser.DeleteUser
{
    public class DeleteUserCommandRequest:IRequest<DeleteUserCommandResponse>
    {
        public string Email { get; set; }
    }
}