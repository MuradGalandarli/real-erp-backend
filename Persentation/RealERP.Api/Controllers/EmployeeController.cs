using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Employee.AddEmployee;
using RealERP.Application.Abstraction.Features.Command.Employee.UpdateEmployee;
using RealERP.Application.Abstraction.Features.Query.Employee.GetByIdEmployee;
using RealERP.Application.Consts;
using RealERP.Application.CustomAttrubutes;
using RealERP.Application.Enums;
using System.Runtime.CompilerServices;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("add-employee")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstans.Employee,Definition ="Add item to employee",ActionType =ActionType.Writing)]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommandRequest addEmployeeCommandRequest)
        {
            AddEmployeeCommandResponse addEmployeeCommandResponse = await _mediator.Send(addEmployeeCommandRequest);
            return Ok(addEmployeeCommandResponse);
        }
        [HttpPut("update-employee")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeCommandRequest updateEmployeeCommandRequest)
        {
            UpdateEmployeeCommandResponse updateEmployeeCommandResponse = await _mediator.Send(updateEmployeeCommandRequest);
            return Ok(updateEmployeeCommandResponse);
        }

        [HttpGet("get-by-id-employee")]
        public async Task<IActionResult> GetByIdEmployee([FromQuery] int id)
        {
            GetByIdEmployeeQueryRequest getByIdEmployeeQueryRequest = new() { Id = id };
            GetByIdEmployeeQueryResponse getByIdEmployeeQueryResponse = await _mediator.Send(getByIdEmployeeQueryRequest);
            return Ok(getByIdEmployeeQueryResponse);
        }

    }
}
