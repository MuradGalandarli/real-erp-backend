using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Department.AddDepartment;
using RealERP.Application.DTOs;
using System.Runtime.CompilerServices;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("add-department")]
        public async Task<IActionResult>AddDepartment([FromBody] AddDepartmentCommandRequest addDepartmentCommandRequest)
        {
            AddDepartmentCommandResponse addDepartmentCommandResponse = await _mediator.Send(addDepartmentCommandRequest);
            return Ok(addDepartmentCommandResponse);
        }

    }
}
