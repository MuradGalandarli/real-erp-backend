using MediatR;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.AppUser.CreateUser;
using RealERP.Application.Abstraction.Features.Command.AppUser.DeleteUser;
using RealERP.Application.Abstraction.Features.Command.AppUser.GetByEmailUser;
using RealERP.Application.Abstraction.Features.Query.AppUser;

namespace RealERP.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetAllUser([FromQuery] int page, [FromQuery] int size)
        { 
            GetAllUserQueryRequest getAllUserQueryRequest = new() { Page = page, Size = size };
            List<GetAllUserQueryResponse> getAllUserQueryResponse = await _mediator.Send(getAllUserQueryRequest);
            return Ok(getAllUserQueryResponse);
        }

        [HttpPost("add-user")]
        public async Task<IActionResult>AddUser([FromBody] CreateUserCommnadRequest createUserCommnadRequest)
        {
            CreateUserCommandResponse createUserCommandResponse = await _mediator.Send(createUserCommnadRequest);
            return Ok(createUserCommandResponse);
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser([FromQuery] string email)
        {
            DeleteUserCommandRequest deleteUserCommandRequest = new() { Email = email };
            DeleteUserCommandResponse deleteUserCommandResponse = await _mediator.Send(deleteUserCommandRequest);
            return Ok(deleteUserCommandResponse);
        }
       [HttpGet("get-by-email-user")]
       public async Task<IActionResult> GetByEmailUser([FromQuery] string email)
        {
            GetByEmailUserCommandRequest getByEmailUserCommandRequest = new() { Email = email };
            GetByEmailUserCommandResponse getByEmailUserCommandResponse = await _mediator.Send(getByEmailUserCommandRequest);
            return Ok(getByEmailUserCommandResponse);
        }



        public IActionResult Index()
        {
            return View();
        }


    }
}
