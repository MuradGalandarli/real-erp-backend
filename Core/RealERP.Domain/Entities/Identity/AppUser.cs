

using Microsoft.AspNetCore.Identity;
using System.Data;

namespace RealERP.Domain.Entities.User
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public Employee? Employee { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
