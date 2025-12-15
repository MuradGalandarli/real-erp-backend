

using Microsoft.EntityFrameworkCore;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Abstraction.Service.UnitOfWork;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
using RealERP.Application.Repositories.DepartmentRepository;
using RealERP.Domain.Entities;
using RealERP.Domain.Entities.User;

namespace RealERP.Persistence.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddDepartmentAsync(DepartmentDto department)
        {
            bool status = await _unitOfWork.writeDepartmentRepository.AddAsync(new() { Name = department.Name });
            if (status)
                await _unitOfWork.writeDepartmentRepository.SaveAsync();
            return status;
        }

        public async Task<bool> DeleteDepartmentByIdAsync(int id)
        {
            Department? department = await _unitOfWork.readDepartmentRepository.GetWhere(department => department.Id == id).
               Include(e => e.Employees).ThenInclude(u => u.User).FirstOrDefaultAsync();

            if (department == null)
                throw new NotFoundException($"Department with id {id} not found");

            await _unitOfWork.BeginTransactionAsync();
            try
            {
               bool statusDepartment = _unitOfWork.writeDepartmentRepository.Delete(department.Id);
                if (department.Employees != null && statusDepartment)
                {
                    foreach (var employee in department.Employees)
                    {
                        bool statusEmployee = _unitOfWork.writeEmployeeRepository.Delete(employee.Id);
                        if(employee.User != null && statusEmployee)
                        {
                           AppUser? user = await _unitOfWork.UserManager.FindByIdAsync(employee.User.Id);
                            if(user != null)
                            {
                               await _unitOfWork.UserManager.DeleteAsync(user);
                            }
                        }
                    }
                    await _unitOfWork.SaveChangesAsync();
                    await _unitOfWork.CommitAsync();

                }
            }
            catch {
                await _unitOfWork.RollbackAsync();
                return false;
            }

            return true;
                
        }

        public List<DepartmentDto> GetAllDepartment(int page, int size)
        {
            IQueryable<Department> departments = _unitOfWork.readDepartmentRepository.GetAll().Skip((page - 1) * size).Take(size);
            return departments.Select(x => new DepartmentDto
            { Name = x.Name,
                Id = x.Id }).ToList();
        }

        public async Task<DepartmentDto> GetByIdDepartmentAsync(int id)
        {
           Department department = await _unitOfWork.readDepartmentRepository.GetByIdAsync(id);
            if(department == null)
                throw new NotFoundException($"Department with id {id} not found");
            return new() { Id = department.Id, Name = department.Name };    
        }

        public async Task<bool> UpdateDepartmentAsync(DepartmentDto department)
        {
            bool status = _unitOfWork.writeDepartmentRepository.Update(new()
            {
                Id = department.Id,
                Name = department.Name,
            });
            if (status)
               await _unitOfWork.writeDepartmentRepository.SaveAsync();
            return status;
        }
    }
}
