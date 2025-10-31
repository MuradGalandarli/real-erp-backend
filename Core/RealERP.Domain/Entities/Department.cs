using RealERP.Domain.Entities.Common;
using RealERP.Domain.Entities.User;


namespace RealERP.Domain.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<AppUser> appUsers { get; set; }
    }
}
