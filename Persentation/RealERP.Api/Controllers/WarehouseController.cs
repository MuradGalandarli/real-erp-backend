using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseAdd;
using RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseDelete;
using RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseUpdate;
using RealERP.Application.Abstraction.Features.Query.Warehouse.GetByIdWarehouse;

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
        [HttpGet("get-by-id-warehouse")]
        public async Task<IActionResult> GetByIdWarehouse([FromQuery] int id)
        {
            GetByIdWarehouseQueryRequest getByIdWarehouseQueryRequest = new() { Id = id };
            GetByIdWarehouseQueryResponse getByIdWarehouseQueryResponse = await _mediator.Send(getByIdWarehouseQueryRequest);
            return Ok(getByIdWarehouseQueryResponse);
        }
        [HttpDelete("delete-warehouse")]
        public async Task<IActionResult> DeleteWarehouse([FromQuery] int id)
        {
            WarehouseDeleteCommandRequest warehouseDeleteCommandRequest = new() { Id = id };
            WarehouseDeleteCommandResponse warehouseDeleteCommandResponse = await _mediator.Send(warehouseDeleteCommandRequest);
            return Ok(warehouseDeleteCommandResponse);
        }
    }
}
