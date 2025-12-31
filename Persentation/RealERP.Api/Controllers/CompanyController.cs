using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Company.AddCompany;
using RealERP.Application.Abstraction.Features.Command.Company.DeleteCompany;
using RealERP.Application.Abstraction.Features.Command.Company.UpdateCompany;
using RealERP.Application.Abstraction.Features.Query.Company.GetByIdCompany;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-company")]
        public async Task<IActionResult> AddCompany([FromBody] AddCompanyCommandRequest addCompanyCommandRequest)
        {
           AddCompanyCommandResponse addCompanyCommandResponse = await _mediator.Send(addCompanyCommandRequest);
            return Ok(addCompanyCommandResponse);
        }
        [HttpPut("update-company")]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyCommandRequest updateCompanyCommandRequest )
        {
            UpdateCompanyCommandResponse updateCompanyCommandResponse = await _mediator.Send(updateCompanyCommandRequest);
            return Ok(updateCompanyCommandResponse);
        }
        [HttpDelete("delete-company")]
        public async Task<IActionResult> DeleteCompany([FromBody] DeleteCompanyCommandRequest deleteCompanyCommandRequest)
        {
            DeleteCompanyCommandResponse deleteCompanyCommandResponse = await _mediator.Send(deleteCompanyCommandRequest);
            return Ok(deleteCompanyCommandResponse);
        }
        [HttpGet("get-by-id-company")]
        public async Task<IActionResult> GetByIdCompany([FromQuery]int id)
        {
            GetByIdCompanyQueryRequest request = new() { Id = id };
            GetByIdCompanyQueryResponse getByIdCompanyQueryResponse = await _mediator.Send(request);
            return Ok(getByIdCompanyQueryResponse);
        }
    }
}
