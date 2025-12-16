
using RealERP.Application.DTOs;


namespace RealERP.Application.Abstraction.Service
{
    public interface IEmployeeService
    {
        public Task<bool> AddEmployeeAsync(EmployeeDto employee);
        public Task<bool> UpdateEmployeeAsync(EmployeeDto employeeDto);
        public Task<EmployeeDto> GetbyIdEmployeeAsync(int id);
        public List<EmployeeDto> GetAllEmployee(int page,int size); 
        public Task<bool> DeleteEmployee(int id); 
    }
}
