using RealERP.Domain.Entities.Common;
using RealERP.Domain.Entities.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealERP.Domain.Entities
{
    public class Employee:BaseEntity
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
    }
}
