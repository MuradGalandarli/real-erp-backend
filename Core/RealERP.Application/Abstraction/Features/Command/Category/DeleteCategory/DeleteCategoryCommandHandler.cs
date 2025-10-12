using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequset, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequset request, CancellationToken cancellationToken)
        {
           bool status =await _categoryService.DeleteCategoryAsync(request.Id);
            return new()
            {
                Status = status,
            };
        }
    }
}
