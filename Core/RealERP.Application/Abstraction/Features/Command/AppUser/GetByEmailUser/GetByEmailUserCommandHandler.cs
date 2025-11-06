

using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Command.AppUser.GetByEmailUser
{
    public class GetByEmailUserCommandHandler : IRequestHandler<GetByEmailUserCommandRequest, GetByEmailUserCommandResponse>
    {
        private readonly IUserService _userServic;

        public GetByEmailUserCommandHandler(IUserService userServic)
        {
            _userServic = userServic;
        }

        public async Task<GetByEmailUserCommandResponse> Handle(GetByEmailUserCommandRequest request, CancellationToken cancellationToken)
        {
            UserDto userDto = await _userServic.GetByEmailUserAsync(request.Email);
            return new()
            {
                Email = userDto.Email,
                DepartmentId = userDto.DepartmentId,
                Name = userDto.Name,
            };
        }
    }
}
