using Microsoft.EntityFrameworkCore;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Abstraction.Service.UnitOfWork;
using RealERP.Application.Exceptions;
using RealERP.Domain.Entities;

namespace RealERP.Persistence.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            int lastOrderId = await _unitOfWork.categoryReadRepository.
                GetWhere(c => c.ParentId == null).MaxAsync(x => (int?)x.OrderIndex) ?? 0;

            Category _category = new()
            {
                Name = category.Name,
                OrderIndex = lastOrderId + 1,
                ParentId = category.ParentId,
                CompanyId = category.CompanyId,
                Description = category.Description,
            };

            bool status = await _unitOfWork.categoryWriteRepository.AddAsync(_category);
            await _unitOfWork.categoryWriteRepository.SaveAsync();
            return status;
        }


        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            bool status = _unitOfWork.categoryWriteRepository.Update(category);
            if (status)
                await _unitOfWork.categoryWriteRepository.SaveAsync();
            return status;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            Category? category = await _unitOfWork.categoryReadRepository.GetWhere(c => c.Id == id).
                Include(p => p.Children).FirstOrDefaultAsync();
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            Category? category = await _unitOfWork.categoryReadRepository.GetWhere(x => x.Id == id).
                Include(c => c.Children).
                 Include(x => x.Products).
                 Include(x => x.Children).FirstOrDefaultAsync();
            if (category == null)
                throw new NotFoundException($"Category with id {id} not found");

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                foreach (var item in category.Children)
                {
                    item.IsDeleted = true;
                }
                foreach (var product in category.Products)
                {
                    product.IsDeleted = true;
                }
                category.IsDeleted = true;

                await _unitOfWork.CommitAsync();
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
            return true;
        }

        public List<Category> GetAllCategory(int page, int size)
        {
            IQueryable<Category> categories = _unitOfWork.categoryReadRepository.GetAll().Skip((page - 1) * size).Take(size).
            OrderBy(x=>x.OrderIndex);

            return categories.ToList();
        }
    }
}
