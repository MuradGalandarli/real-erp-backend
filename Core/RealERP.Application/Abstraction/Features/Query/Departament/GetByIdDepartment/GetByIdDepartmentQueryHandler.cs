using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Departament.GetByIdDepartment
{
    public class GetByIdDepartmentQueryHandler : IRequestHandler<GetByIdDepartmentQueryRequest, GetByIdDepartmentQueryResponse>
    {
        private readonly IDepartmentService _departamentService;

        public GetByIdDepartmentQueryHandler(IDepartmentService departamentService)
        {
            _departamentService = departamentService;
        }

        public async Task<GetByIdDepartmentQueryResponse> Handle(GetByIdDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
            DepartmentDto departmentDto = await _departamentService.GetByIdDepartmentAsync(request.Id);
            return new() { Id = request.Id, Name = departmentDto.Name,CompanyId = departmentDto.CompanyId };
        }
    }
}
