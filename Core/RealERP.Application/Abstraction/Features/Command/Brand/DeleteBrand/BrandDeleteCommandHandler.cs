

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Brand.DeleteBrand
{
    public class BrandDeleteCommandHandler : IRequestHandler<BrandDeleteCommandRequest, BrandDeleteCommandResponse>
    {
        private readonly IBrandService _brandService;

        public BrandDeleteCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<BrandDeleteCommandResponse> Handle(BrandDeleteCommandRequest request, CancellationToken cancellationToken)
        {
           bool status = await _brandService.DeleteBrandAsync(request.Id);
            return new()
            {
                Status = status
            };
        }
    }
}
