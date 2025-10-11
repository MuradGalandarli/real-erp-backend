

using RealERP.Domain.Entities;

namespace RealERP.Application.Abstraction.Service
{
    public interface ICategoryService
    {
        public Task<bool> AddCategoryAsync(Category category);
        public Task<bool> UpdateCategoryAsync(Category category);
    }
}
