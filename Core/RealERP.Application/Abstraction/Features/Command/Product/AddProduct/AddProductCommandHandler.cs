

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Product.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IProductService _productService;

        public AddProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _productService.AddProductAsync(new()
            {
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Name = request.Name,
            });
            return new()
            {
                Status = status,
            };
        }
    }
}
