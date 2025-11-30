using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Query.Employee.GetAllEmployee;

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
        public async Task<IActionResult> GetALLEmployee([FromQuery]int page, [FromQuery]int size)
        {
            GetAllEmployeeQueryRequest getAllEmployeeQueryRequest = new() { Page = page, Size = size };
            GetAllEmployeeQueryResponse getAllEmployeeQueryResponse = await _mediator.Send(getAllEmployeeQueryRequest);
            return Ok(getAllEmployeeQueryResponse);
        }


    }
}
