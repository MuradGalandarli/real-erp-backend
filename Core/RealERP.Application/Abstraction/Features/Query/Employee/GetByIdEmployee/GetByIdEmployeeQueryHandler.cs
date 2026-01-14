using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Employee.GetByIdEmployee
{
    public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQueryRequest, GetByIdEmployeeQueryResponse>
    {
        private readonly IEmployeeService _employeeService;

        public GetByIdEmployeeQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<GetByIdEmployeeQueryResponse> Handle(GetByIdEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            EmployeeDto employee = await _employeeService.GetbyIdEmployeeAsync(request.Id);
            return new()
            {
                Id = employee.Id,
                DepartmentId = employee.DepartmentId,
                FullName = employee.FullName,
                Position = employee.Position,
                UserId = employee.UserId,
                CompanyId = employee.CompanyId,
            };
        }
    }
}
