using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.AppUser.UpdateUser
{
    public class UpdateUserCommandRequest:IRequest<UpdateUserCommandResponse>
    {
        public string? Id { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}