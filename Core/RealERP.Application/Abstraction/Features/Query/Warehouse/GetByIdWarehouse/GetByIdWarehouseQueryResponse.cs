namespace RealERP.Application.Abstraction.Features.Query.Warehouse.GetByIdWarehouse
{
    public class GetByIdWarehouseQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
    }
}