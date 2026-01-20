using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Query.Role.GetAllRole;

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

    }
}
