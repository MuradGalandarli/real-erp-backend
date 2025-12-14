using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Department.AddDepartment;
using RealERP.Application.Abstraction.Features.Command.Department.UpdateDepartment;
using RealERP.Application.Abstraction.Features.Query.Brand.GetAllBrand;
using RealERP.Application.Abstraction.Features.Query.Departament.GetAllDepartment;
using RealERP.Application.Abstraction.Features.Query.Departament.GetByIdDepartment;

namespace RealERP.UI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-all-department")]
        public async Task<IActionResult> GetAllDepartment([FromQuery] int page, [FromQuery] int size)
        {
            GetAllDepartmentQueryRequest getAllDepartmentQueryRequest = new() { Page = page, Size = size };
            List<GetAllDepartmentQueryResponse> getAllDepartmentQueryResponse = await _mediator.Send(getAllDepartmentQueryRequest);
            return Ok(getAllDepartmentQueryResponse);
        }
        [HttpPost("add-department")]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentCommandRequest addDepartmentCommandRequest)
        {
            AddDepartmentCommandResponse addDepartmentCommandResponse = await _mediator.Send(addDepartmentCommandRequest);
            return Ok(addDepartmentCommandRequest);
        }
        [HttpGet("get-By-Id")]
        public async Task<IActionResult> GetByIdDepartment([FromQuery]int id)
        {
            GetByIdDepartmentQueryRequest getByIdDepartmentQueryRequest = new() { Id = id };
            GetByIdDepartmentQueryResponse getByIdDepartmentQueryResponse = await _mediator.Send(getByIdDepartmentQueryRequest);
            return Ok(getByIdDepartmentQueryResponse);
        }
        [HttpPut("update-department")]
        public async Task<IActionResult>UpdateDepartment([FromBody]UpdateDepartmentCommandRequest updateDepartmentCommandRequest)
        {
            UpdateDepartmentCommandResponse updateDepartmentCommandResponse = await _mediator.Send(updateDepartmentCommandRequest);
            return Ok(updateDepartmentCommandResponse);
        }

       




    }
}
