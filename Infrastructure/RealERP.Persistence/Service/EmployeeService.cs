using RealERP.Application.Abstraction.Service;
using RealERP.Application.Abstraction.Service.UnitOfWork;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
using RealERP.Domain.Entities;

namespace RealERP.Persistence.Service
{
    public class EmployeeService : IEmployeeService
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddEmployeeAsync(EmployeeDto employee)
        { 
            bool hasEmployee = false;
            if (!string.IsNullOrEmpty(employee.UserId))
            {
                 hasEmployee = _unitOfWork.readEmployeeRepository.Table.Any(x => x.UserId == employee.UserId);
            }
                if (!hasEmployee)
                {
                    bool status = await _unitOfWork.writeEmployeeRepository.AddAsync(new()
                    {
                        DepartmentId = employee.DepartmentId,
                        FullName = employee.FullName,
                        UserId = employee.UserId,
                        Position = employee.Position,
                        CompanyId = employee.CompanyId
                    });
                    if (status)
                       
                            await _unitOfWork.writeEmployeeRepository.SaveAsync();

                    return status;
                }
            
            return false;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            bool removed = _unitOfWork.writeEmployeeRepository.Delete(id);
            if (removed)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false; 
        }

        public List<EmployeeDto> GetAllEmployee(int page, int size)
        {
           IQueryable<Employee> employees = _unitOfWork.readEmployeeRepository.GetAll().Skip((page-1)*size).Take(size);
            return employees.Select(e=> new EmployeeDto {
                FullName = e.FullName,
                DepartmentId=e.DepartmentId,
                Id = e.Id,
                UserId = e.UserId,
                Position = e.Position,
                CompanyId = e.CompanyId
            }).ToList();
        }

        public async Task<EmployeeDto> GetbyIdEmployeeAsync(int id)
        {
          Employee employee = await _unitOfWork.readEmployeeRepository.GetByIdAsync(id);
            if(employee == null)
                throw new NotFoundException($"Department with id {id} not found");
            return new()
            {
                DepartmentId = employee.DepartmentId,
                FullName = employee.FullName,
                UserId = employee.UserId,
                Position = employee.Position,
                Id = employee.Id,
                CompanyId = employee.CompanyId
            };

        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = await _unitOfWork.readEmployeeRepository.GetByIdAsync(employeeDto.Id);
            if (employee == null)
                return false;

            employee.FullName = employeeDto.FullName;
            employee.DepartmentId = employeeDto.DepartmentId;
            employee.Position = employeeDto.Position;
            employee.CompanyId = employeeDto.CompanyId;

            await _unitOfWork.writeEmployeeRepository.SaveAsync();
            return true;
        }


    }
}

