using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.AppUser.UpdateUser
{
    public class UpdateUserCommandRequest:IRequest<UpdateUserCommandResponse>
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string Name { get; set; }
    }
}