using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Query.Brand.GetAllBrand;
using RealERP.Application.Abstraction.Features.Query.Departament.GetAllDepartment;

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
        public async Task<IActionResult> GetAllDepartment([FromQuery]int page, [FromQuery]int size)
        {
          GetAllDepartmentQueryRequest getAllDepartmentQueryRequest = new() { Page = page, Size = size };
            List<GetAllDepartmentQueryResponse> getAllDepartmentQueryResponse = await _mediator.Send(getAllDepartmentQueryRequest);
            return Ok(getAllDepartmentQueryResponse);

        }


    }
}
