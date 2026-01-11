using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Company.AddCompany;
using RealERP.Application.Abstraction.Features.Command.Company.UpdateCompany;
using RealERP.Application.Abstraction.Features.Query.Company.GetAllCompany;
using RealERP.Application.Abstraction.Features.Query.Company.GetByIdCompany;

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
        public async Task<IActionResult> GetAllCompany([FromQuery] int page, [FromQuery] int size)
        {
            GetAllCompanyQueryRequest getAllCompanyQueryRequest = new() { Page = page, Size = size };
            GetAllCompanyQueryResponse getAllCompanyQueryResponse = await _mediator.Send(getAllCompanyQueryRequest);
            return Ok(getAllCompanyQueryResponse);
        }

        [HttpPost("add-company")]
        public async Task<IActionResult> AddCompany([FromBody] AddCompanyCommandRequest addCompanyCommandRequest)
        {
            AddCompanyCommandResponse addCompanyCommandResponse = await _mediator.Send(addCompanyCommandRequest);
            return Ok(addCompanyCommandResponse);
        }
        [HttpGet("get-by-id-company")]
        public async Task<IActionResult> GetByIdCompany([FromQuery] int id)
        {
            GetByIdCompanyQueryRequest getByIdCompanyQueryRequest = new() { Id = id };
            GetByIdCompanyQueryResponse getByIdCompanyQueryResponse = await _mediator.Send(getByIdCompanyQueryRequest);
            return Ok(getByIdCompanyQueryResponse);
        }
        [HttpPut("update-company")]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyCommandRequest updateCompanyCommandRequest)
            {
            UpdateCompanyCommandResponse updateCompanyCommandResponse = await _mediator.Send(updateCompanyCommandRequest);
            return Ok(updateCompanyCommandResponse);

        }
    }
}
