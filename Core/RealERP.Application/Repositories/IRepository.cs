
using Microsoft.EntityFrameworkCore;

namespace RealERP.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
       public DbSet<T> Table { get; }
    }
}
