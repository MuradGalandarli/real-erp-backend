﻿

using RealERP.Application.DTOs;
using System.Runtime.CompilerServices;

namespace RealERP.Application.Abstraction.Service
{
    public interface IProductService
    {
        public Task<bool> AddProductAsync(ProductDto productDto);
        public Task<bool> UpdateProductAsync(ProductDto productDto);
        public Task<bool> DeleteProductAsync(int id);
        public Task<ProductDto> GetByIdProduct(int id);
        public List<ProductDto> GetAllProduct(int page, int size);
    }
}
