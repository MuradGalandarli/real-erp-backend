using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealERP.Application.Abstraction.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealERP.Application.Abstraction.Features.Command.AppUser.GetRolesToUser
{
    internal class GetRolesToUserCommandHandler : IRequestHandler<GetRolesToUserCommandRequest, GetRolesToUserCommandResponse>
    {
        private readonly IUserService _userService;

        public GetRolesToUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetRolesToUserCommandResponse> Handle(GetRolesToUserCommandRequest request, CancellationToken cancellationToken)
        {
            string[] roles = await _userService.GetRolesToUserAsync(request.UserId);
            return new()
            {
                Roles = roles
            };

        }
    }
}
