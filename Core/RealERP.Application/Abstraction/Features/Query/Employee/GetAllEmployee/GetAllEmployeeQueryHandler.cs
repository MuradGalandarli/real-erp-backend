

using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Employee.GetAllEmployee
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQueryRequest, GetAllEmployeeQueryResponse>
    {
        private readonly IEmployeeService _employeeService;

        public GetAllEmployeeQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<GetAllEmployeeQueryResponse> Handle(GetAllEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
          List<EmployeeDto> employees  = _employeeService.GetAllEmployee(request.Page, request.Size);
            return new()
            {
                Employees = employees,
            };
        }
    }
}
