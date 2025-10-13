
using RealERP.Application.Abstraction.Service;
using RealERP.Domain.Entities;
using RealERP.Persistence.Repositories.CategoryRepository;

namespace RealERP.Persistence.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IWriteCategoryRepository _categoryRepository;
        private readonly IReadCategoryRepository _readCategoryRepository;

        public CategoryService(IReadCategoryRepository readCategoryRepository, IWriteCategoryRepository categoryRepository)
        {
            _readCategoryRepository = readCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        public CategoryService(IWriteCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
           bool status = await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
            return status;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
           Category category = await _readCategoryRepository.GetByIdAsync(id);
            return category;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            bool status = _categoryRepository.Update(category);
            if (status)
               await _categoryRepository.SaveAsync();
            return status;
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
           bool status = _categoryRepository.Delete(id);
            await _categoryRepository.SaveAsync();
            return status;
        }

        public List<Category> GetAllCategory(int page, int size)
        {
            IQueryable<Category> categories  = _readCategoryRepository.GetAll().Skip((page-1)*size).Take(size);
            return categories.ToList();
        }
    }
}
