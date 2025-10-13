using RealERP.Domain.Entities;

namespace RealERP.Application.Abstraction.Service
{
    public interface ICategoryService
    {
        public Task<bool> AddCategoryAsync(Category category);
        public Task<bool> UpdateCategoryAsync(Category category);
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<bool> DeleteCategoryAsync(int id);
        public List<Category> GetAllCategory(int page, int size);
    }
}
