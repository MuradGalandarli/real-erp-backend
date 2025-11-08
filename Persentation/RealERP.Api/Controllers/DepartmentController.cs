using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Department.AddDepartment;
using RealERP.Application.Abstraction.Features.Command.Department.DeleteDepartment;
using RealERP.Application.Abstraction.Features.Query.Departament.GetAllDepartment;
using RealERP.Application.Abstraction.Features.Query.Departament.GetByIdDepartment;


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
        [HttpGet("get-all-department")]
        public async Task<IActionResult> GetAllDepartment([FromQuery] int Page, [FromQuery] int Size)
        {
            GetAllDepartmentQueryRequest getAllDepartmentQueryRequest = new() { Page = Page, Size = Size };
            List<GetAllDepartmentQueryResponse> getAllDepartmentQueryResponse = await _mediator.Send(getAllDepartmentQueryRequest);
            return Ok(getAllDepartmentQueryResponse);
        }
        [HttpGet("get-by-id-department")]
        public async Task<IActionResult> GetByIdDepartment([FromQuery]int id)
        {
            GetByIdDepartmentQueryRequest getByIdDepartmentQueryRequest = new() { Id = id };
            GetByIdDepartmentQueryResponse getByIdDepartmentQueryResponse = await _mediator.Send(getByIdDepartmentQueryRequest);
            return Ok(getByIdDepartmentQueryResponse);
        }
        [HttpDelete("delete-department")]
        public async Task<IActionResult> DeleteDepartment([FromQuery] int id)
        {
            DeleteDepartmentCommandRequest deleteDepartmentCommandRequest = new() { Id = id };
            DeleteDepartmentCommandResponse deleteDepartmentCommandResponse = await _mediator.Send(deleteDepartmentCommandRequest);
            return Ok(deleteDepartmentCommandResponse);
        }
    }
}
