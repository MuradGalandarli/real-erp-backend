

using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Service
{
    public interface IEmployeeService
    {
        public Task<bool> AddEmployee(EmployeeDto employee);
    }
}
