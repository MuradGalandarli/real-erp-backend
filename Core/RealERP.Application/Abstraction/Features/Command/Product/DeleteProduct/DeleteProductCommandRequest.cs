using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Product.DeleteProduct
{
    public class DeleteProductCommandRequest:IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }
    }
}