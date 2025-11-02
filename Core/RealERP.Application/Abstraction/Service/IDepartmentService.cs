using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Service
{
    public interface IDepartmentService
    {
        public Task<bool> AddDepartmentAsync(DepartmentDto department);
    }
}
