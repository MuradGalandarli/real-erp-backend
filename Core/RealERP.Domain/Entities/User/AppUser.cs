

using Microsoft.AspNetCore.Identity;

namespace RealERP.Domain.Entities.User
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public Employee? Employee { get; set; }
    }
}
