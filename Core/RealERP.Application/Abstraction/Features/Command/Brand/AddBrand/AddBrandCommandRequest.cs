using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Brand.AddBrand
{
    public class AddBrandCommandRequest : IRequest<AddBrandCommandResponse>
    {
        public string BrandName { get; set; }
    }
}