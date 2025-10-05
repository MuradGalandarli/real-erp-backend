using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RealERP.Application.Abstraction.Features.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}