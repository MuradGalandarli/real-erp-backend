using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Department.UpdateDepartment
{
    public class UpdateDepartmentCommandRequest:IRequest<UpdateDepartmentCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
    }
}