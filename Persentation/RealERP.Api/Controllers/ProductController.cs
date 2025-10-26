using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Product.AddProduct;
using RealERP.Application.Abstraction.Features.Command.Product.UpdateProduct;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommandRequest addProductCommandRequest)
        {
            AddProductCommandResponse addProductCommandResponse = await _mediator.Send(addProductCommandRequest);
            return Ok(addProductCommandResponse);
        }
        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse updateProductCommandResponse = await _mediator.Send(updateProductCommandRequest);
            return Ok(updateProductCommandResponse);    
        }
    }
}
