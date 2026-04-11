using Microsoft.AspNetCore.Http;

namespace RealERP.Application.DTOs
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? CompanyId { get; set; }
        public List<IFormFile> Images { get; set; } = new();
        public List<int> DeletedImageIds { get; set; } = new();

    }
}
