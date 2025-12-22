
using Microsoft.EntityFrameworkCore;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Abstraction.Service.UnitOfWork;
using RealERP.Domain.Entities;
using RealERP.Persistence.Repositories.CategoryRepository;

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
           bool status = await _unitOfWork.categoryWriteRepository.AddAsync(category);
            await  _unitOfWork.categoryWriteRepository.SaveAsync();
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
            Category category = await _unitOfWork.categoryReadRepository.GetByIdAsync(id);
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {

            //bool status = _unitOfWork.categoryWriteRepository.Delete(id);
            IQueryable<Category> category = _unitOfWork.categoryReadRepository.GetWhere(x => x.Id == id).
                 Include(x => x.Products);
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                foreach (var item in category)
                {
                    foreach (var product in item.Products)
                    {
                        _unitOfWork.writeProductRepository.Delete(product.Id);
                        
                    }
                    _unitOfWork.categoryWriteRepository.Delete(id);
                }
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
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
            IQueryable<Category> categories  = _unitOfWork.categoryReadRepository.GetAll().Skip((page-1)*size).Take(size);
            return categories.ToList();
        }
    }
}
