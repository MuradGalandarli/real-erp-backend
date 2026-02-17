using RealERP.Domain.Entities;


namespace RealERP.Application.DTOs
{
    public class ProductRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? CompanyId { get; set; }
        public List<ProductImage> ProductImages { get; set; } = new();
    }
}
