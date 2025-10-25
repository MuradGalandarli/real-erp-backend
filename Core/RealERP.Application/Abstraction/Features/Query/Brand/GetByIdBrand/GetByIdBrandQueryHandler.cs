

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Query.Brand.GetByIdBrand
{
    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQueryRequest, GetByIdBrandQueryResponse>
    {
        private readonly IBrandService _brandService;

        public GetByIdBrandQueryHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<GetByIdBrandQueryResponse> Handle(GetByIdBrandQueryRequest request, CancellationToken cancellationToken)
        {
           Domain.Entities.Brand brand = await _brandService.GetByIdBrandAsync(request.Id);
            return new()
            {
                Id = request.Id,
                BrandName = brand.Name,
            };
        }
    }
}
