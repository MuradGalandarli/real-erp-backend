using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Service
{
    public interface IDepartmentService
    {
        public Task<bool> AddDepartmentAsync(DepartmentDto department);
        public List<DepartmentDto> GetAllDepartment(int page,int size);
        public Task<DepartmentDto> GetByIdDepartmentAsync(int id);
    }
}
