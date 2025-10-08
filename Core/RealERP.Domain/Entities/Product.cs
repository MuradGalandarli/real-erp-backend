using RealERP.Domain.Entities.Common;


namespace RealERP.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }  
        public ICollection<Warehouse> Warehouses { get; set; }
        
    }
}
