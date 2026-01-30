namespace RealERP.Application.Abstraction.Features.Query.Product.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? CompanyId { get; set; }
    }
}