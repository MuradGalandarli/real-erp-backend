using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Role.CreateRole;
using RealERP.Application.Abstraction.Features.Command.Role.UpdateRole;
using RealERP.Application.Abstraction.Features.Query.Role.RoleGetById;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
        {
            CreateRoleCommandResponse createRoleCommandResponse = await _mediator.Send(createRoleCommandRequest); 
            return Ok(createRoleCommandResponse);
        }
        [HttpPut("update-role")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            UpdateRoleCommandResponse updateRoleCommandResponse = await _mediator.Send(updateRoleCommandRequest);
            return Ok(updateRoleCommandResponse);
        }
        [HttpGet("get-by-id-role")]
        public async Task<IActionResult>GetByIdRole(RoleGetByIdQueryRequest roleGetByIdQueryRequest)
        {
            RoleGetByIdQueryResponse roleGetByIdQueryResponse = await _mediator.Send(roleGetByIdQueryRequest);
            return Ok(roleGetByIdQueryResponse);
        }



    }
}
