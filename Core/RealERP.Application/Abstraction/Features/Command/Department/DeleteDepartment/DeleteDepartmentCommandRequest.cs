using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Department.DeleteDepartment
{
    public class DeleteDepartmentCommandRequest:IRequest<DeleteDepartmentCommandResponse>
    {
        public int Id { get; set; }
    }
}