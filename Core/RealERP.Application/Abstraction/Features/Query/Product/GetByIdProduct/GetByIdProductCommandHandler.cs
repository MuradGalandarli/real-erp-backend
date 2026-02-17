

using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Product.GetByIdProduct
{
    public class GetByIdProductCommandHandler : IRequestHandler<GetByIdProductCommandRequest, GetByIdProductCommandResponse>
    {
        private readonly IProductService _productService;

        public GetByIdProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetByIdProductCommandResponse> Handle(GetByIdProductCommandRequest request, CancellationToken cancellationToken)
        {
            ProductRequestDto productDto = await _productService.GetByIdProduct(request.Id);
            return new()
            {
                Id = productDto.Id,
                BrandId = productDto.BrandId,
                CategoryId = productDto.CategoryId,
                Description = productDto.Description,
                Name = productDto.Name,
                CompanyId = productDto.CompanyId,
                ProductImages = productDto.ProductImages,
            };
        }
    }
}
