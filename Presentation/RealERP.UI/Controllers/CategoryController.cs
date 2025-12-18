using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Query.Brand.GetAllBrand;
using RealERP.Application.Abstraction.Features.Query.Category.GetAllCategory;

namespace RealERP.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-category")]
        public async Task<IActionResult> GetAllCategory([FromQuery]int page, [FromQuery] int size)
        {
            GetAllCategoryQueryRequest getAllCategoryQueryRequest = new() { Size = size ,Page = page};
            List<GetAllCategoryQueryResponse> getAllBrandQueryResponse = await _mediator.Send(getAllCategoryQueryRequest);
            return Ok(getAllBrandQueryResponse);
        }
        
    }
}
