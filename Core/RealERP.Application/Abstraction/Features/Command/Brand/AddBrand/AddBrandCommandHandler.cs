

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Brand.AddBrand
{
    public class AddBrandCommandHandler : IRequestHandler<AddBrandCommandRequest, AddBrandCommandResponse>
    {
        private readonly IBrandService _brandService;

        public AddBrandCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<AddBrandCommandResponse> Handle(AddBrandCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _brandService.AddBrnadAsync(new() { Name = request.BrandName, CompanyId = request.CompanyId });
            return new()
            {
                Status = status,
            };
        }
    }
}
