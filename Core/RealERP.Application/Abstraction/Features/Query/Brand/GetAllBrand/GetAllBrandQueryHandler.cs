
using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Query.Brand.GetAllBrand
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQueryRequest, List<GetAllBrandQueryResponse>>
    {
        private readonly IBrandService _brandService;

        public GetAllBrandQueryHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<List<GetAllBrandQueryResponse>> Handle(GetAllBrandQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Brand> brands = _brandService.GetAllBrand(request.Page, request.Size);
            return brands.Select(b=> new GetAllBrandQueryResponse()
            {
                Id = b.Id,
                BrandName = b.Name
            }).ToList();
        }
    }
}
