using Microsoft.EntityFrameworkCore;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
using RealERP.Application.Repositories.EmployeeRepository;
using RealERP.Domain.Entities;

namespace RealERP.Persistence.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IWriteEmployeeRepository _writeEmployeeRepository;
        private readonly IReadEmployeeRepository _readEmployeeRepository;

        public EmployeeService(IWriteEmployeeRepository writeEmployeeRepository, IReadEmployeeRepository readEmployeeRepository)
        {
            _writeEmployeeRepository = writeEmployeeRepository;
            _readEmployeeRepository = readEmployeeRepository;
        }

        public async Task<bool> AddEmployeeAsync(EmployeeDto employee)
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

        public List<EmployeeDto> GetAllEmployee(int page, int size)
        {
           IQueryable<Employee> employees = _readEmployeeRepository.GetAll().Skip((page-1)*size).Take(size);
            return employees.Select(e=> new EmployeeDto {
                FullName = e.FullName,
                DepartmentId=e.DepartmentId,
                Id = e.Id,
                Position = e.Position,
            }).ToList();
        }

        public async Task<EmployeeDto> GetbyIdEmployeeAsync(int id)
        {
          Employee employee = await _readEmployeeRepository.GetByIdAsync(id);
            if(employee == null)
                throw new NotFoundException($"Department with id {id} not found");
            return new()
            {
                DepartmentId = employee.DepartmentId,
                FullName = employee.FullName,
                UserId = employee.UserId,
                Position = employee.Position,
                Id = employee.Id
            };

        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
          bool status = _writeEmployeeRepository.Update(new()
            {
                Id = employeeDto.Id,
                DepartmentId = employeeDto.DepartmentId,
                FullName = employeeDto.FullName,
                UserId = employeeDto.UserId,
                Position = employeeDto.Position,
            });
            if(status)
                await _writeEmployeeRepository.SaveAsync();
            return status;

        }
    }
}
