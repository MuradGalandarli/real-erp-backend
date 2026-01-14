

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Employee.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommandRequest, AddEmployeeCommandResponse>
    {
        private readonly IEmployeeService _employeeService;

        public AddEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<AddEmployeeCommandResponse> Handle(AddEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _employeeService.AddEmployeeAsync(new() 
            {
                DepartmentId = request.DepartmentId,
                FullName = request.FullName,
                Position = request.Position,
                UserId = request.UserId,
                CompanyId = request.CompanyId,
            });
            return new()
            {
                Status = status,
            };

        }
    }
}
