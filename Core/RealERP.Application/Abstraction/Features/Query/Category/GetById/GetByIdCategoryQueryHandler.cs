
using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Query.Category.GetById
{
   
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly ICategoryService _categoryService;

        public GetByIdCategoryQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
          
          Domain.Entities.Category category = await _categoryService.GetCategoryById(request.Id);
            if (category != null)
            {
                return new()
                {
                    Description = category.Description,
                    Id = request.Id,
                    Name = category.Name,
                };
            }
            return new() { };
        }
    }
}
