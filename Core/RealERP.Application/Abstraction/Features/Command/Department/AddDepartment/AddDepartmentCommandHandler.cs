using MediatR;
using RealERP.Application.Abstraction.Service;


namespace RealERP.Application.Abstraction.Features.Command.Department.AddDepartment
{
    public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommandRequest, AddDepartmentCommandResponse>
    {
        private readonly IDepartmentService _departmentService;

        public AddDepartmentCommandHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<AddDepartmentCommandResponse> Handle(AddDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
           bool status = await _departmentService.AddDepartmentAsync(new() { Name = request.Name ,CompanyId = request.CompanyId});
            return new()
            {
                Status = status,
            };
        }
    }
}
