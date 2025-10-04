using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RealERP.Application.Abstraction.Features.Command.AppUser.CreateUser;

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


    }
}
