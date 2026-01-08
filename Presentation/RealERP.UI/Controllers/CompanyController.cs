using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Query.Company.GetAllCompany;

namespace RealERP.UI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-company")]
        public async Task<IActionResult> GetAllCompany([FromQuery]int page, [FromQuery]int size)
        {
            GetAllCompanyQueryRequest getAllCompanyQueryRequest = new() { Page = page, Size = size };
            GetAllCompanyQueryResponse getAllCompanyQueryResponse = await _mediator.Send(getAllCompanyQueryRequest);
            return Ok(getAllCompanyQueryResponse);

        }
    }
}
