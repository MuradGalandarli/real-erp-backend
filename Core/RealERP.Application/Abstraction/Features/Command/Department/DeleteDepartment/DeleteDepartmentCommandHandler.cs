

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Department.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommandRequest, DeleteDepartmentCommandResponse>
    {
        private readonly IDepartmentService _departmentServic;

        public DeleteDepartmentCommandHandler(IDepartmentService departmentServic)
        {
            _departmentServic = departmentServic;
        }

        public async Task<DeleteDepartmentCommandResponse> Handle(DeleteDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
             bool status = await _departmentServic.DeleteDepartmentByIdAsync(request.Id);
            return new()
            {
                Status = status,
            };
        }
    }
}
