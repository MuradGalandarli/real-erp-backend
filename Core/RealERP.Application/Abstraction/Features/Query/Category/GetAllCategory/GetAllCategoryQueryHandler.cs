using MediatR;
using RealERP.Application.Abstraction.Service;


namespace RealERP.Application.Abstraction.Features.Query.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<GetAllCategoryQueryResponse>>
    {
        private readonly ICategoryService _categoryService;

        public GetAllCategoryQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryService.GetAllCategory(request.Page, request.Size);

            return categories.Select(x=> new GetAllCategoryQueryResponse() 
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
            }).ToList();

            
        }

      
    }
}
