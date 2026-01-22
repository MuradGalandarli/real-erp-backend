using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Role.UpdateRole;
using RealERP.Application.Abstraction.Features.Query.Brand.GetByIdBrand;
using RealERP.Application.Abstraction.Features.Query.Role.GetAllRole;
using RealERP.Application.Abstraction.Features.Query.Role.RoleGetById;

namespace RealERP.UI.Controllers
{
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-role")]
        public async Task<IActionResult> GetAllRole([FromQuery]int page, [FromQuery]int size)
        {
            GetAllRoleQueryRequest getAllRoleQueryRequest = new() { Page = page, Size = size };
            List<GetAllRoleQueryResponse> getAllRoleQueryResponse = await _mediator.Send(getAllRoleQueryRequest);
            return Ok(getAllRoleQueryResponse);
        }
        [HttpGet("get-by-id-role")]
        public async Task<IActionResult> GetByIdRole([FromQuery] string id)
        {
            RoleGetByIdQueryRequest roleGetByIdQueryRequest = new() { Id = id };
            RoleGetByIdQueryResponse roleGetByIdQueryResponse = await _mediator.Send(roleGetByIdQueryRequest);
            return Ok(roleGetByIdQueryResponse);
        }
        [HttpPut("update-role")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            UpdateRoleCommandResponse updateRoleCommandResponse = await _mediator.Send(updateRoleCommandRequest);
            return Ok(updateRoleCommandResponse);
        }

        
    }
}
