using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Product
{
    public class AddProductCommandRequest:IRequest<AddProductCommandResponse>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}