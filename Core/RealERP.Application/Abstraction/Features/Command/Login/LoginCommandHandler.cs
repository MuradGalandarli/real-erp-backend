using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        async Task<LoginCommandResponse> IRequestHandler<LoginCommandRequest, LoginCommandResponse>.Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            LoginResponseDto loginResponseDto = await _authService.LoginAsync(new() { Username = request.Username, Password = request.Password });
            return new()
            {
                Expiration = loginResponseDto.Expiration,
                Token = loginResponseDto.Token,
            };
        }
    }
}
