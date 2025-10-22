using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Brand.AddBrand;
using RealERP.Application.Abstraction.Features.Command.Brand.UpdateBrand;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-brand")]
        public async Task<IActionResult> AddBrand(AddBrandCommandRequest addBrandCommandRequest)
        {
            AddBrandCommandResponse addBrandCommandResponse = await _mediator.Send(addBrandCommandRequest);
            return Ok(addBrandCommandResponse);
        }
        [HttpPut("update-brand")]
        public async Task<IActionResult> UpdateBrnad([FromBody] BrandUpdateCommandRequest brandUpdateCommandRequest)
        {
            BrandUpdateCommandResponse brandUpdateCommandResponse = await _mediator.Send(brandUpdateCommandRequest);
            return Ok(brandUpdateCommandResponse);
        }


    }
}
