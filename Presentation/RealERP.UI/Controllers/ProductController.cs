using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using RealERP.Application.Abstraction.Features.Command.Product.AddProduct;
using RealERP.Application.Abstraction.Features.Command.Product.UpdateProduct;
using RealERP.Application.Abstraction.Features.Query.Product.GetAllProduct;
using RealERP.Application.Abstraction.Features.Query.Product.GetByIdProduct;

namespace RealERP.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-product")]
        public async Task<IActionResult> GetAllProduct([FromQuery] int page, [FromQuery] int size)
        {
            GetAllProductQueryRequest getAllProductQueryRequest = new() { Page = page, Size = size };
            List<GetAllProductQueryResponse> getAllProductQueryResponses = await _mediator.Send(getAllProductQueryRequest);
            return Ok(getAllProductQueryResponses);
        }
        [HttpGet("get-by-id-product")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            GetByIdProductCommandRequest getByIdProductCommandRequest = new() { Id = id };
            GetByIdProductCommandResponse getByIdProductCommandResponse = await _mediator.Send(getByIdProductCommandRequest);
            return Ok(getByIdProductCommandResponse);
        }
        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse updateProductCommandResponse = await _mediator.Send(updateProductCommandRequest);
            return Ok(updateProductCommandResponse);
        }
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody]AddProductCommandRequest addProductCommandRequest)
        {
            AddProductCommandResponse addProductCommandResponse = await _mediator.Send(addProductCommandRequest);
            return Ok(addProductCommandResponse);
        }
    }
}
