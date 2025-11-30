using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Employee.GetAllEmployee
{
    public class GetAllEmployeeQueryResponse
    {
        public List<EmployeeDto> Employees { get; set; }
    }
}