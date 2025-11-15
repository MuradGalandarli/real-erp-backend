using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RealERP.Application.Abstraction.Features.Command.AppUser.CreateUser
{
    public class CreateUserCommnadRequest : IRequest<CreateUserCommandResponse>
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string Name { get; set; }

    }
}