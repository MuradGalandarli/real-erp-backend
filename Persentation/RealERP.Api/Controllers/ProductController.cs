﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using RealERP.Application.Abstraction.Features.Command.Product.AddProduct;
using RealERP.Application.Abstraction.Features.Command.Product.DeleteProduct;
using RealERP.Application.Abstraction.Features.Command.Product.UpdateProduct;
using RealERP.Application.Abstraction.Features.Query.Product.GetAllProduct;
using RealERP.Application.Abstraction.Features.Query.Product.GetByIdProduct;

namespace RealERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommandRequest addProductCommandRequest)
        {
            AddProductCommandResponse addProductCommandResponse = await _mediator.Send(addProductCommandRequest);
            return Ok(addProductCommandResponse);
        }
        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse updateProductCommandResponse = await _mediator.Send(updateProductCommandRequest);
            return Ok(updateProductCommandResponse);
        }
        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct([FromQuery] int id)
        {
            DeleteProductCommandRequest deleteProductCommandRequest = new() { Id = id };
            DeleteProductCommandResponse deleteProductCommandResponse = await _mediator.Send(deleteProductCommandRequest);
            return Ok(deleteProductCommandResponse);
        }
        [HttpGet("get-by-id-product")]
        public async Task<IActionResult> GetByIdProduct([FromQuery] int id)
        {
            GetByIdProductCommandRequest getByIdProductCommandRequest = new() { Id = id };
            GetByIdProductCommandResponse getByIdProductCommandResponse = await _mediator.Send(getByIdProductCommandRequest);
            return Ok(getByIdProductCommandResponse);
        }

        [HttpGet("get-all-product")]
        public async Task<IActionResult> GetAllProduct([FromQuery] int page, [FromQuery]int size)
        {
            GetAllProductQueryRequest getAllProductQueryRequest = new() { Page = page, Size = size };
            List<GetAllProductQueryResponse> getAllProductQueryResponse = await _mediator.Send(getAllProductQueryRequest);    
            return Ok(getAllProductQueryResponse);  

        }

    }
}
