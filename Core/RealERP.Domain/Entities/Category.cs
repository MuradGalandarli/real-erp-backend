using RealERP.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace RealERP.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public int? ParentId { get; set; }
        public Category? Parent { get; set; }
        public int? OrderIndex { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Category> Children { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
