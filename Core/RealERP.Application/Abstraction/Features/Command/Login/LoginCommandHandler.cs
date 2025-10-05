using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IUserService _userService;

        public LoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        async Task<LoginCommandResponse> IRequestHandler<LoginCommandRequest, LoginCommandResponse>.Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            LoginResponseDto loginResponseDto = await _userService.LoginAsync(new() { Username = request.Username, Password = request.Password });
            return new()
            {
                Expiration = loginResponseDto.Expiration,
                Token = loginResponseDto.Token,
            };
        }
    }
}
