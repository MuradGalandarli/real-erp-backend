

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Role.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        private readonly IRoleServices _roleServices;

        public UpdateRoleCommandHandler(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _roleServices.UpdateRole(new() { id = request.Id, Name = request.Name });
            return new()
            {
                Status = status
            };
        }
    }
}
