

using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;
using RealERP.Application.Repositories.DepartmentRepository;

namespace RealERP.Persistence.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IWriteDepartmentRepository _writeDepartmentRepository;

        public DepartmentService(IWriteDepartmentRepository writeDepartmentRepository)
        {
            _writeDepartmentRepository = writeDepartmentRepository;
        }

        public async Task<bool> AddDepartmentAsync(DepartmentDto department)
        {
            bool status = await _writeDepartmentRepository.AddAsync(new() { Name = department.Name });
            if (status)
                await _writeDepartmentRepository.SaveAsync();
            return status;
        }
    }
}
