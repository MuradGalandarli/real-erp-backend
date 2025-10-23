using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Brand.DeleteBrand
{
    public class BrandDeleteCommandRequest:IRequest<BrandDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}