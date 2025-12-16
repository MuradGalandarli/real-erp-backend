

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Employee.DeleteEmployee
{
    public class DeleteEmployeCommandHandler : IRequestHandler<DeleteEmployeCommandRequest, DeleteEmployeCommandResponse>
    {
        private readonly IEmployeeService _employeeService;

        public DeleteEmployeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<DeleteEmployeCommandResponse> Handle(DeleteEmployeCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _employeeService.DeleteEmployee(request.Id);
            return new()
            {
                Status = status
            };

        }
    }
}
