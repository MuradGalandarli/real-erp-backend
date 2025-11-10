using RealERP.Domain.Entities.Common;
using RealERP.Domain.Entities.User;

namespace RealERP.Domain.Entities
{
    public class Employee:BaseEntity
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
