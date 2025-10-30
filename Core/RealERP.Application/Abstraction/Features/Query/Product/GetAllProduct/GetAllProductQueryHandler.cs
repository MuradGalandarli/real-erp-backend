

using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly IProductService _productService;

        public GetAllProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
           List<ProductDto> productDtos = _productService.GetAllProduct(request.Page, request.Size);
            return productDtos.Select(p => new GetAllProductQueryResponse()
            {
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Id = p.Id,
                Name = p.Name,
            }).ToList();
        }
    }
}
