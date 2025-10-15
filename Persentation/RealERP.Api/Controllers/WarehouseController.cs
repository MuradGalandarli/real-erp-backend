using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseAdd;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("add-warehouse")]
        public async Task<IActionResult> AddWarehouse([FromBody]AddWarehouseCommandRequest addWarehouseCommandRequest)
        {
            AddWarehouseCommandResponse addWarehouseCommandResponse =await _mediator.Send(addWarehouseCommandRequest);
            return Ok(addWarehouseCommandResponse);
        }
    }
}
