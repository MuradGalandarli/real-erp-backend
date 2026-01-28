using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseAdd;
using RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseUpdate;
using RealERP.Application.Abstraction.Features.Query.Brand.GetAllBrand;
using RealERP.Application.Abstraction.Features.Query.Warehouse.GetAllWarehouse;
using RealERP.Application.Abstraction.Features.Query.Warehouse.GetByIdWarehouse;

namespace RealERP.UI.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-warehouse")]
        public async Task<IActionResult> GetAllWarehouse([FromQuery]int page, [FromQuery]int size)
        {
            GetAllWarehouseQueryRequest getAllWarehouseQueryRequest = new() { Page = page, Size = size };
            List<GetAllWarehouseQueryResponse> getAllWarehouseQueryResponse = await _mediator.Send(getAllWarehouseQueryRequest);
            return Ok(getAllWarehouseQueryResponse);
        }
        [HttpGet("get-by-id-warehouse")]
        public async Task<IActionResult> GetByIdWarehouse([FromQuery] int id)
        {
            GetByIdWarehouseQueryRequest getByIdWarehouseQueryRequest = new() { Id = id };
            GetByIdWarehouseQueryResponse getByIdWarehouseQueryResponse = await _mediator.Send(getByIdWarehouseQueryRequest);
            return Ok(getByIdWarehouseQueryResponse);
        }
        [HttpPut("update-warehouse")]
        public async Task<IActionResult> UpdateWarehouse([FromBody]UpdateWarehouseCommandRequest updateWarehouseCommandRequest)
        {
            UpdateWarehouseCommandResponse updateWarehouseCommandResponse = await _mediator.Send(updateWarehouseCommandRequest);
            return Ok(updateWarehouseCommandResponse);
        }
        [HttpPost("add-warehouse")]
        public async Task<IActionResult> AddWarehouse([FromBody] AddWarehouseCommandRequest addWarehouseCommandRequest)
        {
            AddWarehouseCommandResponse addWarehouseCommandResponse = await _mediator.Send(addWarehouseCommandRequest);
            return Ok(addWarehouseCommandResponse);
        }
    }
}
