using Microsoft.EntityFrameworkCore;
using RealERP.Application.Repositories;
using RealERP.Domain.Entities.Common;
using RealERP.Persistence.Context;
using System.Linq.Expressions;

namespace RealERP.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
           
            return Table;
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await Table.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return await Table.FirstOrDefaultAsync(method);
        }

        public  IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
           return Table.Where(method);
        }
    }
}
