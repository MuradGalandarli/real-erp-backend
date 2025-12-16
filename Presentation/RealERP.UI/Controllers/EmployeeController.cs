using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Employee.AddEmployee;
using RealERP.Application.Abstraction.Features.Command.Employee.UpdateEmployee;
using RealERP.Application.Abstraction.Features.Query.Employee.GetAllEmployee;
using RealERP.Application.Abstraction.Features.Query.Employee.GetByIdEmployee;

namespace RealERP.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("get-all-employee")]
        public async Task<IActionResult> GetALLEmployee([FromQuery] int page, [FromQuery] int size)
        {
            GetAllEmployeeQueryRequest getAllEmployeeQueryRequest = new() { Page = page, Size = size };
            GetAllEmployeeQueryResponse getAllEmployeeQueryResponse = await _mediator.Send(getAllEmployeeQueryRequest);
            return Ok(getAllEmployeeQueryResponse);
        }
        [HttpGet("get-By-Id-Employee")]
        public async Task<IActionResult> GetByIdEmploye([FromQuery] int id)
        {
            GetByIdEmployeeQueryRequest getByIdEmployeeQueryRequest = new() { Id = id };
            GetByIdEmployeeQueryResponse getByIdEmployeeQueryResponse = await _mediator.Send(getByIdEmployeeQueryRequest);
            return Ok(getByIdEmployeeQueryResponse);
        }
        [HttpPut("update-employee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommandRequest updateEmployeeCommandRequest)
        {
            UpdateEmployeeCommandResponse updateEmployeeCommandResponse = await _mediator.Send(updateEmployeeCommandRequest);
            return Ok(updateEmployeeCommandResponse);
        }
        [HttpPost("add-employee")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommandRequest addEmployeeCommandRequest)
        {
            AddEmployeeCommandResponse addEmployeeCommandResponse = await _mediator.Send(addEmployeeCommandRequest);
            return Ok(addEmployeeCommandResponse);
        }
       


    }
}
