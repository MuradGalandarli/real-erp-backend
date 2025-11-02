using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Department.AddDepartment
{
    public class AddDepartmentCommandRequest:IRequest<AddDepartmentCommandResponse>
    {
        public string Name { get; set; }
    }
}