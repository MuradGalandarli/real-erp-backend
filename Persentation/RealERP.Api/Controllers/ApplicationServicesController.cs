using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Configurations;
using RealERP.Application.Consts;
using RealERP.Application.CustomAttrubutes;
using RealERP.Application.DTOs.Configuration;
using RealERP.Application.Enums;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationServicesController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading,Definition ="Get Authorize Definition Endpoint",Menu = AuthorizeDefinitionConstans.ApplicationService)]
        public IActionResult GetAuthorizeDefinitionEndpoint() 
        {
           List<Menu> menus = _applicationService.GetAuthorizeDefinitionEndpoint(typeof(Program));
            return Ok(menus);
        }

    }
}
