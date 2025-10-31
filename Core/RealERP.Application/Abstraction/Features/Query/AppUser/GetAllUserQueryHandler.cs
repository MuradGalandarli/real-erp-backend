

using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.AppUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, List<GetAllUserQueryResponse>>
    {
        private readonly IUserService _userService;

        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<GetAllUserQueryResponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
           List<UserDto> userDtos = await _userService.GetAllUser(request.Page,request.Size);

            return userDtos.Select(u => new GetAllUserQueryResponse()
            {
                DepartmentId = u.DepartmentId,
                Email = u.Email,
                Name = u.Name,

            }).ToList();
        }
    }
}
