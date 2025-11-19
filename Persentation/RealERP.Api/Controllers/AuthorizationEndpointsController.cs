using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.AuthorizationEndpoint.AssignRoleEndpoint;
using RealERP.Application.Abstraction.Features.Query.AuthorizationEndpoint.GetRolesToEndpoints;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-roles-to-endpoint")]
        public async Task<IActionResult> GetRolesToEndpoint([FromBody] GetRolesToEndpointQueryRequest getRolesToEndpointQueryRequest)
        {
             
            GetRolesToEndpointQueryResponse getRolesToEndpointQueryResponse = await _mediator.Send(getRolesToEndpointQueryRequest);
            return Ok(getRolesToEndpointQueryResponse);
        }


        [HttpPost]
        public async Task<IActionResult> AssignRoleEndpoint([FromBody]AssignRoleEndpointCommandRequest assignRoleEndpointCommandRequest)
        {
            assignRoleEndpointCommandRequest.Type = typeof(Program);  
            AssignRoleEndpointCommandResponse assignRoleEndpointCommandResponse = await _mediator.Send(assignRoleEndpointCommandRequest);
            return Ok(assignRoleEndpointCommandResponse);
        }
    }
}
