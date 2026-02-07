namespace RealERP.Application.Abstraction.Features.Query.Category.GetById
{
    public class GetByIdCategoryQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CompanyId { get; set; }
        public List<Domain.Entities.Category> Children { get; set; } = new();
    }
}