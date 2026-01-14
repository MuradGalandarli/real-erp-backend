

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
    {
        private readonly  IEmployeeService _employeeService;

        public UpdateEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _employeeService.UpdateEmployeeAsync(new()
            {
                Id = request.Id,
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
