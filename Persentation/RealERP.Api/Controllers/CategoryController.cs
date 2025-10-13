using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealERP.Application.Abstraction.Features.Command.Category.AddCategory;
using RealERP.Application.Abstraction.Features.Command.Category.DeleteCategory;
using RealERP.Application.Abstraction.Features.Command.Category.UpdateCategory;
using RealERP.Application.Abstraction.Features.Query.Category.GetAllCategory;
using RealERP.Application.Abstraction.Features.Query.Category.GetById;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommandRequest addCategoryCommandRequest)
        {
            AddCategoryCommandResponse addCategoryCommandResponse = await _mediator.Send(addCategoryCommandRequest);
            return Ok(addCategoryCommandResponse);
        }
        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse updateCategoryCommandResponse = await _mediator.Send(updateCategoryCommandRequest);

            return Ok(updateCategoryCommandResponse);
        }
        [HttpGet("get-by-id-category")]
        public async Task<IActionResult> GetByIdCategory([FromQuery] int id)
        {
            GetByIdCategoryQueryRequest getByIdCategoryQueryRequest = new() { Id = id };
            GetByIdCategoryQueryResponse getByIdCategoryQueryResponse = await _mediator.Send(getByIdCategoryQueryRequest);
            return Ok(getByIdCategoryQueryResponse);
        }
        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategory([FromQuery] int id)
        {
            DeleteCategoryCommandRequset deleteCategoryCommandRequset = new() { Id = id };
            DeleteCategoryCommandResponse deleteCategoryCommandResponse = await _mediator.Send(deleteCategoryCommandRequset);
            return Ok(deleteCategoryCommandResponse);
        }
        [HttpGet("get-all-category")]
        public async Task<IActionResult> GetAllCategory([FromQuery] int page, [FromQuery] int size)
        {
            GetAllCategoryQueryRequest getAllCategoryQueryRequest = new()
            {
                Page = page,
                Size = size
            };
            List<GetAllCategoryQueryResponse> getByIdCategoryQueryResponse = await _mediator.Send(getAllCategoryQueryRequest);
            return Ok(getByIdCategoryQueryResponse);
        }
    }
}
