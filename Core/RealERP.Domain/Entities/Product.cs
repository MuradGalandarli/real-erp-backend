using RealERP.Domain.Entities.Common;


namespace RealERP.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int? CategoryId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Category? Category { get; set; }
        public ICollection<WarehouseProduct> WarehouseProducts { get; set; }
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }

    }
}
