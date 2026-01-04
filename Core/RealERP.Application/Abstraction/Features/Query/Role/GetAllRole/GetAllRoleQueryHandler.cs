using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Role.GetAllRole
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQueryRequest, List<GetAllRoleQueryResponse>>
    {
        private readonly IRoleServices _roleServices;

        public GetAllRoleQueryHandler(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public async Task<List<GetAllRoleQueryResponse>> Handle(GetAllRoleQueryRequest request, CancellationToken cancellationToken)
        {
         List<RoleDto> roles = await _roleServices.GetAllRole(request.Page, request.Size);
            return roles.Select(r => new GetAllRoleQueryResponse
            {
                id = r.id,
               Name = r.Name
            }).ToList();
           
        }
    }
}
