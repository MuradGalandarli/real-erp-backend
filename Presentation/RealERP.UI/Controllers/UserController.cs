using MediatR;
using Microsoft.AspNetCore.Mvc;
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


        public IActionResult Index()
        {
            return View();
        }


    }
}
