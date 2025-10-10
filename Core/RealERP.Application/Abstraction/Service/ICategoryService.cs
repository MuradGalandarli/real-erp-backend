

using RealERP.Domain.Entities;

namespace RealERP.Application.Abstraction.Service
{
    public interface ICategoryService
    {
        public Task<bool> AddCategory(Category category);
    }
}
