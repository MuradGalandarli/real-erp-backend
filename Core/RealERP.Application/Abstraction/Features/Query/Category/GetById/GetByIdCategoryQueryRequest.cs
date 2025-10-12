using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Category.GetById
{
    public class GetByIdCategoryQueryRequest:IRequest<GetByIdCategoryQueryResponse>
    {
        public int Id { get; set; }
    }
}