using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Department.UpdateDepartment
{
    public class UpdateDepartmentCommandRequest:IRequest<UpdateDepartmentCommandResponse>
    {
        public string Name { get; set; }
    }
}