using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Brand.UpdateBrand
{
    public class BrandUpdateCommandRequest:IRequest<BrandUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public int CompanyId { get; set; }
    }
}