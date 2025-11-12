using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Employee.GetByIdEmployee
{
    public class GetByIdEmployeeQueryRequest:IRequest<GetByIdEmployeeQueryResponse>
    {
        public int Id { get; set; } 
    }
}