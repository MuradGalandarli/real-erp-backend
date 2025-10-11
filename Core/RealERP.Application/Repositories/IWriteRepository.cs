
namespace RealERP.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T : class
    {
        public Task<bool> AddAsync(T model);
        public Task<bool> AddRange(List<T> datas);  
        public bool Update(T t);
        public bool DeleteAsync(int id);
        public bool DeleteRange(List<T> id);
        Task<int> SaveAsync();        
    }
}
