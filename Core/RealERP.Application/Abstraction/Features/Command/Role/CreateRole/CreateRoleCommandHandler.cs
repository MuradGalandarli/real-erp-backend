

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Role.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        private readonly IRoleServices _roleServices;

        public CreateRoleCommandHandler(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _roleServices.AddRole(new() { Name = request.Name });
            return new()
            {
                Status = status
            };
        }
    }
}
