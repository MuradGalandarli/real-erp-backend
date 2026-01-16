
using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Brand.UpdateBrand
{
    public class BrandUpdateCommandHandler : IRequestHandler<BrandUpdateCommandRequest, BrandUpdateCommandResponse>
    {
        private readonly IBrandService _brandService;

        public BrandUpdateCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<BrandUpdateCommandResponse> Handle(BrandUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _brandService.UpdateBrandAsync(new() {Id = request.Id, Name = request.BrandName,CompanyId = request.CompanyId });
            return new()
            {
                Status = status
            };
        }
    }
}
