using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Category.AddCategory
{
    public class AddCategoryCommandRequest:IRequest<AddCategoryCommandResponse>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CompanyId { get; set; }
    }
}