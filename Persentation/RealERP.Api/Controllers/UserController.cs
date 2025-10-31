using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RealERP.Application.Abstraction.Features.Command.AppUser.CreateUser;
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
        public async Task<IActionResult> CreateUser(CreateUserCommnadRequest createUserCommnadRequest)
        {
           CreateUserCommandResponse createUserCommandResponse = await _mediator.Send(createUserCommnadRequest);
            return Ok(createUserCommandResponse);
        }
        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetAllUser(int page, int size)
        {
            GetAllUserQueryRequest getAllUserQueryRequest = new() { Page = page, Size = size };
            List<GetAllUserQueryResponse> getAllUserQueryResponses = await _mediator.Send(getAllUserQueryRequest);
            return Ok(getAllUserQueryResponses);
        }

    }
}
