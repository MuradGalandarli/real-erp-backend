using RealERP.Domain.Entities.Common;


namespace RealERP.Domain.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
