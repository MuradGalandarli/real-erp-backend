using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Employee.DeleteEmployee
{
    public class DeleteEmployeCommandRequest:IRequest<DeleteEmployeCommandResponse>
    {
        public int Id { get; set; }
    }
}