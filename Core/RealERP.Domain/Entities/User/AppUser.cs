

using Microsoft.AspNetCore.Identity;

namespace RealERP.Domain.Entities.User
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
