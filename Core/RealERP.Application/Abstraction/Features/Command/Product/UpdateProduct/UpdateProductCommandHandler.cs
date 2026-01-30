

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _productService.UpdateProductAsync(new()
            {
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Id = request.Id,
                Name = request.Name ,
                CompanyId = request.CompanyId,
            });
            return new()
            {
                Status = status,
            };
        }
    }
}
