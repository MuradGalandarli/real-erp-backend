using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;
using RealERP.Application.Repositories.EmployeeRepository;

namespace RealERP.Persistence.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IWriteEmployeeRepository _writeEmployeeRepository;

        public EmployeeService(IWriteEmployeeRepository writeEmployeeRepository)
        {
            _writeEmployeeRepository = writeEmployeeRepository;
        }

        public async Task<bool> AddEmployee(EmployeeDto employee)
        {
          bool status = await _writeEmployeeRepository.AddAsync(new()
            {
                DepartmentId = employee.DepartmentId,
                FullName = employee.FullName,
                UserId = employee.UserId,
                Position = employee.Position,
            });
            if(status)
            await _writeEmployeeRepository.SaveAsync();
            return status;
        }
    }
}
