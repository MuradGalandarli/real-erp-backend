using MediatR;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Employee.GetAllEmployee
{
    public class GetAllEmployeeQueryRequest:IRequest<GetAllEmployeeQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}