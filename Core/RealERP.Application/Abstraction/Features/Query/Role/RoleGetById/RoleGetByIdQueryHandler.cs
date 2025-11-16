

using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Role.RoleGetById
{
    public class RoleGetByIdQueryHandler : IRequestHandler<RoleGetByIdQueryRequest, RoleGetByIdQueryResponse>
    {
        private readonly IRoleServices _roleServices;

        public RoleGetByIdQueryHandler(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public async Task<RoleGetByIdQueryResponse> Handle(RoleGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            RoleDto role = await _roleServices.GetByIdAsync(request.Id);
            return new()
            {
                id = role.id,
                Name = role.Name
            };
        }
    }
}
