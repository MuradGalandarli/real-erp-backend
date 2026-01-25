namespace RealERP.Application.Abstraction.Features.Query.Warehouse.GetAllWarehouse
{
    public class GetAllWarehouseQueryResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int CompanyId { get; set; }
    }
}