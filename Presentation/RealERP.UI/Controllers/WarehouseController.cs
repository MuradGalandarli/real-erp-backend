using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}
