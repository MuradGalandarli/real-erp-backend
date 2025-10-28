using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Product.GetByIdProduct
{
    public class GetByIdProductCommandRequest:IRequest<GetByIdProductCommandResponse>
    {
        public int Id { get; set; }
       
    }
}