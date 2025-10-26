

using RealERP.Domain.Entities;

namespace RealERP.Application.DTOs.RequestDto
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
       
    }
}
