using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommandRequest:IRequest<UpdateEmployeeCommandResponse>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public string? UserId { get; set; }
        public int? CompanyId { get; set; }
    }
}