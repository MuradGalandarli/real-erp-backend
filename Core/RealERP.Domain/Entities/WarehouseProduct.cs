using RealERP.Domain.Entities.Common;

namespace RealERP.Domain.Entities
{
    public class WarehouseProduct:BaseEntity
    {
        public int? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public int StockCount { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
