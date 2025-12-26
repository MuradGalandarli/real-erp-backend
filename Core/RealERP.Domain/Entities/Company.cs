using RealERP.Domain.Entities.Common;
using RealERP.Domain.Entities.User;
using RealERP.Domain.Enum;


namespace RealERP.Domain.Entities
{
    public class Company:BaseEntity
    {
        public string Name { get; set; } = null!;
        public CompanyStatus Status { get; set; } = CompanyStatus.Active;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<AppUser> Users { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Warehouse> Warehouses { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Category> Categories { get; set; }
    
}
}
