
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RealERP.Application.Repositories;
using RealERP.Domain.Entities.Common;
using RealERP.Persistence.Context;

namespace RealERP.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
           EntityEntry entityEntry = await Table.AddAsync(model);
           return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRange(List<T> datas)
        {
           await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Delete(int id)
        {
           var data = Table.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                EntityEntry entityEntry = Table.Remove(data);
                return entityEntry.State == EntityState.Deleted;
            }
            return false;
        }

        public bool DeleteRange(List<T> id)
        {
           Table.RemoveRange(id);
            return true;
        }

        public async Task<int> SaveAsync()
        {
           int count = await _context.SaveChangesAsync();
            return count;
        }

        public bool Update(T t)
        {
           EntityEntry entityEntry = Table.Update(t);
           return entityEntry.State == EntityState.Modified;
        }
    }
}
