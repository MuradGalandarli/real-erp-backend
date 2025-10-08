using RealERP.Domain.Entities.Common;


namespace RealERP.Domain.Entities
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
