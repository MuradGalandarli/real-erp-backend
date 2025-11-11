

using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Service
{
    public interface IEmployeeService
    {
        public Task<bool> AddEmployeeAsync(EmployeeDto employee);
        public Task<bool> UpdateEmployeeAsync(EmployeeDto employeeDto);
    }
}
