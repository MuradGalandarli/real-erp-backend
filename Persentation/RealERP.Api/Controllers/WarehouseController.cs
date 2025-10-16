using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseAdd;
using RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseUpdate;

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
        public async Task<IActionResult> AddWarehouse([FromBody] AddWarehouseCommandRequest addWarehouseCommandRequest)
        {
            AddWarehouseCommandResponse addWarehouseCommandResponse = await _mediator.Send(addWarehouseCommandRequest);
            return Ok(addWarehouseCommandResponse);
        }
        [HttpPut("update-warehouse")]
        public async Task<IActionResult> UpdateWarehouse([FromBody] UpdateWarehouseCommandRequest updateWarehouseCommandRequest)
        {
            UpdateWarehouseCommandResponse updateWarehouseCommandResponse = await _mediator.Send(updateWarehouseCommandRequest);
            return Ok(updateWarehouseCommandResponse);
        }
    }
}
