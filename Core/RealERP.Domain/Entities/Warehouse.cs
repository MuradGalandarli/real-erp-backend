﻿using RealERP.Domain.Entities.Common;

namespace RealERP.Domain.Entities
{
    public class Warehouse:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
