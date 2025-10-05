using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Login;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public AuthController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginCommandRequest loginQueryRequest)
        {
            LoginCommandResponse loginQuery = await _mediatR.Send(loginQueryRequest);
            return Ok(loginQuery);
        }
    }
}
