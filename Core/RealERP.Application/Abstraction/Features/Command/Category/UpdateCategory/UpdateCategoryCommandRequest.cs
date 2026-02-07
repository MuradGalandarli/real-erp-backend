using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Category.UpdateCategory
{
    public class UpdateCategoryCommandRequest:IRequest<UpdateCategoryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CompanyId { get; set; }
        public int? ParentId { get; set; }
    }
}