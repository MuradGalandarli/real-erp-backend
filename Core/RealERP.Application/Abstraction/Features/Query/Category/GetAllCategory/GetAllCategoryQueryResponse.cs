namespace RealERP.Application.Abstraction.Features.Query.Category.GetAllCategory
{
    public class GetAllCategoryQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CompanyId { get; set; }
        public int? ParentId { get; set; }
        public int? OrderIndex { get; set; }
    }
}