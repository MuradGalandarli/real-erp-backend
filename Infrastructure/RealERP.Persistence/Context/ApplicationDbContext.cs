using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealERP.Domain.Entities;
using RealERP.Domain.Entities.Identity;
using RealERP.Domain.Entities.User;


namespace RealERP.Persistence.Context
{
    public class ApplicationDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Company>().HasQueryFilter(c => !c.IsDeleted);
            builder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Brand>().HasQueryFilter(b => !b.IsDeleted);
            builder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
            builder.Entity<Warehouse>().HasQueryFilter(w => !w.IsDeleted);
            builder.Entity<Department>().HasQueryFilter(w => !w.IsDeleted);
            builder.Entity<Employee>().HasQueryFilter(w => !w.IsDeleted);
            builder.Entity<AppUser>().HasQueryFilter(u => !u.IsDeleted);

            builder.Entity<Company>().HasIndex(c => c.Name).IsUnique();    
        }

    }
}
