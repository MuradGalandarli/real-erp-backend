using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Role.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {
        private readonly IRoleServices roleServices;

        public DeleteRoleCommandHandler(IRoleServices roleServices)
        {
            this.roleServices = roleServices;
        }

        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await roleServices.DeleteRole(request.Id);
            return new()
            {
                Status = status,
            };
        }
    }
}
