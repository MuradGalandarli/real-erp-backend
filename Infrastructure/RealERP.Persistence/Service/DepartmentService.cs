

using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
using RealERP.Application.Repositories.DepartmentRepository;
using RealERP.Domain.Entities;

namespace RealERP.Persistence.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IWriteDepartmentRepository _writeDepartmentRepository;
        private readonly IReadDepartmentRepository _readDepartmentRepository;

        public DepartmentService(IWriteDepartmentRepository writeDepartmentRepository, IReadDepartmentRepository readDepartmentRepository)
        {
            _writeDepartmentRepository = writeDepartmentRepository;
            _readDepartmentRepository = readDepartmentRepository;
        }

        public async Task<bool> AddDepartmentAsync(DepartmentDto department)
        {
            bool status = await _writeDepartmentRepository.AddAsync(new() { Name = department.Name });
            if (status)
                await _writeDepartmentRepository.SaveAsync();
            return status;
        }

        public async Task<bool> DeleteDepartmentByIdAsync(int id)
        {
           bool status = _writeDepartmentRepository.Delete(id);
            if (status)
                await _writeDepartmentRepository.SaveAsync();
            return status;
        }

        public List<DepartmentDto> GetAllDepartment(int page, int size)
        {
            IQueryable<Department> departments = _readDepartmentRepository.GetAll().Skip((page - 1) * size).Take(size);
            return departments.Select(x => new DepartmentDto
            { Name = x.Name,
                Id = x.Id }).ToList();
        }

        public async Task<DepartmentDto> GetByIdDepartmentAsync(int id)
        {
           Department department = await _readDepartmentRepository.GetByIdAsync(id);
            if(department == null)
                throw new NotFoundException($"Department with id {id} not found");
            return new() { Id = department.Id, Name = department.Name };    
        }

        public async Task<bool> UpdateDepartmentAsync(DepartmentDto department)
        {
            bool status = _writeDepartmentRepository.Update(new()
            {
                Name = department.Name,
            });
            if (status)
               await _writeDepartmentRepository.SaveAsync();
            return status;
        }
    }
}
