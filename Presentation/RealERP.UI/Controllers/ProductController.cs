using MediatR;
using Microsoft.AspNetCore.Mvc;
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


    }
}
