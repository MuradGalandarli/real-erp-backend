using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Brand.AddBrand;
using RealERP.Application.Abstraction.Features.Query.Brand.GetAllBrand;

namespace RealERP.UI.Controllers
{
    public class BrandController : Controller
    {
       
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-brand")]
        public async Task<IActionResult> GetAllBrand([FromQuery]int page, [FromQuery]int size)
        {
            GetAllBrandQueryRequest getAllBrandQueryRequest = new() { Page = page, Size = size };
            List<GetAllBrandQueryResponse> getAllBrandQueryResponse = await _mediator.Send(getAllBrandQueryRequest);
            return Ok(getAllBrandQueryResponse);
        }
        [HttpPost("add-brnad")]
        public async Task<IActionResult> AddBrand([FromBody] AddBrandCommandRequest addBrandCommandRequest)
        {
            AddBrandCommandResponse addBrandCommandResponse = await _mediator.Send(addBrandCommandRequest);
            return Ok(addBrandCommandResponse);

        }
    }
}
