

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
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                CompanyId = request.CompanyId
                
            });
            return new()
            {
                Status = status,
            };

        }
    }
}
