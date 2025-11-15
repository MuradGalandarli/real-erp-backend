

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.AppUser.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUserService _userService;
         
        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
           bool status = await _userService.UpdateUserAsync(new()
            {
                Name = request.Name,
                Email = request.Email,
                Username = request.Username,
            });
            return new()
            {
                Status = status,
            };

        }
    }
}
