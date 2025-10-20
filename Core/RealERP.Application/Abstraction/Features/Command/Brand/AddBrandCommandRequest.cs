using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Brand
{
    public class AddBrandCommandRequest:IRequest<AddBrandCommandResponse>
    {
        public string BrandName { get; set; }
    }
}