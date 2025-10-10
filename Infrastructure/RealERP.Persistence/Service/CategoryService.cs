
using RealERP.Application.Abstraction.Service;
using RealERP.Domain.Entities;
using RealERP.Persistence.Repositories.CategoryRepository;

namespace RealERP.Persistence.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IWriteCategoryRepository _categoryRepository;

        public CategoryService(IWriteCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> AddCategory(Category category)
        {
           bool status = await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
            return status;
        }
    }
}
