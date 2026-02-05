using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealERP.Domain.Entities.User
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public Employee? Employee { get; set; } 
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
