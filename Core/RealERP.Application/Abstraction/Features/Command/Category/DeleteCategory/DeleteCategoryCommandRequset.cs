using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Category.DeleteCategory
{
    public class DeleteCategoryCommandRequset:IRequest<DeleteCategoryCommandResponse>
    {
        public int Id { get; set; }
    }
}