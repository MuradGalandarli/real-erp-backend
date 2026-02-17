using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.AppUser.CreateUser;
using RealERP.Application.Abstraction.Features.Command.AppUser.DeleteUser;
using RealERP.Application.Abstraction.Features.Command.AppUser.GetByEmailUser;
using RealERP.Application.Abstraction.Features.Command.AppUser.GetRolesToUser;
using RealERP.Application.Abstraction.Features.Command.AppUser.UpdateUser;
using RealERP.Application.Abstraction.Features.Command.AssignRoleToUser;
using RealERP.Application.Abstraction.Features.Query.AppUser;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("creaate-user")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommnadRequest createUserCommnadRequest)
        {
           CreateUserCommandResponse createUserCommandResponse = await _mediator.Send(createUserCommnadRequest);
            return Ok(createUserCommandResponse);
        }
        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetAllUser([FromQuery]int page, [FromQuery]int size)
        {
            GetAllUserQueryRequest getAllUserQueryRequest = new() { Page = page, Size = size };
            List<GetAllUserQueryResponse> getAllUserQueryResponses = await _mediator.Send(getAllUserQueryRequest);
            return Ok(getAllUserQueryResponses);
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest updateUserCommandRequest)
        {
            UpdateUserCommandResponse updateUserCommandResponse = await _mediator.Send(updateUserCommandRequest);
            return Ok(updateUserCommandResponse);
        }

        [HttpGet("get-by-email-user")]
        public async Task<IActionResult> GetByEmailUser([FromQuery] string email)
        {
            GetByEmailUserCommandRequest getByEmailUserCommandRequest = new() { Email = email };
            GetByEmailUserCommandResponse getByEmailUserCommandResponse = await _mediator.Send(getByEmailUserCommandRequest);
            return Ok(getByEmailUserCommandResponse);
        }
        [HttpDelete("delete-user-by-email")]
        public async Task<IActionResult> DeleteUser([FromQuery] string email)
        {
            DeleteUserCommandRequest deleteUserCommandRequest = new() { Email = email };
            DeleteUserCommandResponse deleteUserCommandResponse = await _mediator.Send(deleteUserCommandRequest);
            return Ok(deleteUserCommandResponse);
        }
        [HttpPost("assign-role-to-user")]
        public async Task<IActionResult> AssignRoleToUser([FromBody]AssignRoleToUserCommandRequest toUserCommandRequest)
        {
            await _mediator.Send(toUserCommandRequest);
            return Ok();
        }
        [HttpGet("get-roles-to-user")]
        public async Task<IActionResult> GetRolesToUser([FromQuery] string userId)
        {
            GetRolesToUserCommandRequest getRolesToUserCommandRequest = new() { UserId = userId };
            GetRolesToUserCommandResponse getRolesToUserCommandResponse = await _mediator.Send(getRolesToUserCommandRequest);
            return Ok(getRolesToUserCommandResponse);
        }
    }
}
