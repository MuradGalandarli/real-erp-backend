using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Departament.GetAllDepartment
{
    public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQueryRequest, List<GetAllDepartmentQueryResponse>>
    {
        private readonly IDepartmentService _departamentService;

        public GetAllDepartmentQueryHandler(IDepartmentService departamentService)
        {
            _departamentService = departamentService;
        }

        public async Task<List<GetAllDepartmentQueryResponse>> Handle(GetAllDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
           List<DepartmentDto> departments = _departamentService.GetAllDepartment(request.Page, request.Size);
            return departments.Select(d => new GetAllDepartmentQueryResponse() {
                Id = d.Id,
            Name = d.Name,
            }).ToList();
            
        }
    }
}
