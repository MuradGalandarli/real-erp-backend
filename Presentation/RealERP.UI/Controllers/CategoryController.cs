using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Category.AddCategory;
using RealERP.Application.Abstraction.Features.Command.Category.DeleteCategory;
using RealERP.Application.Abstraction.Features.Command.Category.UpdateCategory;
using RealERP.Application.Abstraction.Features.Query.Brand.GetAllBrand;
using RealERP.Application.Abstraction.Features.Query.Brand.GetByIdBrand;
using RealERP.Application.Abstraction.Features.Query.Category.GetAllCategory;
using RealERP.Application.Abstraction.Features.Query.Category.GetById;

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
        public async Task<IActionResult> GetAllCategory([FromQuery] int page, [FromQuery] int size)
        {
            GetAllCategoryQueryRequest getAllCategoryQueryRequest = new() { Size = size, Page = page };
            List<GetAllCategoryQueryResponse> getAllBrandQueryResponse = await _mediator.Send(getAllCategoryQueryRequest);
            return Ok(getAllBrandQueryResponse);
        }
        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommandRequest addCategoryCommandRequest)
        {
            AddCategoryCommandResponse addCategoryCommandResponse = await _mediator.Send(addCategoryCommandRequest);
            return Ok(addCategoryCommandResponse);
        }
        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategory([FromQuery] int id)
        {
            DeleteCategoryCommandRequset deleteCategoryCommandRequset = new() { Id = id };
            DeleteCategoryCommandResponse deleteCategoryCommandResponse = await _mediator.Send(deleteCategoryCommandRequset);
            return Ok(deleteCategoryCommandResponse);
        }
        [HttpGet("get-by-id-category")]
        public async Task<IActionResult> GetByIdCategory([FromQuery] int id)
        {
            GetByIdCategoryQueryRequest getByIdCategoryQueryRequest = new() { Id = id };
            GetByIdCategoryQueryResponse getByIdCategoryQueryResponse = await _mediator.Send(getByIdCategoryQueryRequest);
            return Ok(getByIdCategoryQueryResponse);
        }
        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory([FromBody]UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse updateCategoryCommandResponse = await _mediator.Send(updateCategoryCommandRequest);
            return Ok(updateCategoryCommandResponse);
        }
        
    }
}
