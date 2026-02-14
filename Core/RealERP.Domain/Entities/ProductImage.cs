

using RealERP.Domain.Entities.Common;

namespace RealERP.Domain.Entities
{
    public class ProductImage:BaseEntity
    {
        public string ImageUrl  { get; set; }
        public string PublicId { get; set; }
        public bool IsMain { get; set; } = false;
        public bool IsDeleted { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
