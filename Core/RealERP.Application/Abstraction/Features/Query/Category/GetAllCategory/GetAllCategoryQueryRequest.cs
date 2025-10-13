using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Category.GetAllCategory
{
    public class GetAllCategoryQueryRequest:IRequest<List<GetAllCategoryQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}