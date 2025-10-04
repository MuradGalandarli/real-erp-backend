using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;


namespace RealERP.Application.Abstraction.Features.Command.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommnadRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommnadRequest request, CancellationToken cancellationToken)
        {
           Response response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                Password = request.Password,
                Username = request.Username,
            });

            return new()
            {
                Message = response.Message,
                Status = response.Status,
            };
        }
    }
}
