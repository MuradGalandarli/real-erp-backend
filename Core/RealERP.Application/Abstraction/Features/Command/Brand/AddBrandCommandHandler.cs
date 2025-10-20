

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Brand
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
            bool status = await _brandService.AddBrnad(new() { Name = request.BrandName });
            return new()
            {
                Status = status,
            };
        }
    }
}
