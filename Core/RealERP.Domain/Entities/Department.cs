using RealERP.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace RealERP.Domain.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
