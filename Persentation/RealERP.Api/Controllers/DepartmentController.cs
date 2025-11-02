using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Department.AddDepartment;
using RealERP.Application.Abstraction.Features.Query.Departament.GetAllDepartment;


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
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentCommandRequest addDepartmentCommandRequest)
        {
            AddDepartmentCommandResponse addDepartmentCommandResponse = await _mediator.Send(addDepartmentCommandRequest);
            return Ok(addDepartmentCommandResponse);
        }
        [HttpPost("get-all-department")]
        public async Task<IActionResult> GetAllDepartment([FromQuery] int Page, [FromQuery] int Size)
        {
            GetAllDepartmentQueryRequest getAllDepartmentQueryRequest = new() { Page = Page, Size = Size };
            List<GetAllDepartmentQueryResponse> getAllDepartmentQueryResponse = await _mediator.Send(getAllDepartmentQueryRequest);
            return Ok(getAllDepartmentQueryResponse);
        }
    }
}
