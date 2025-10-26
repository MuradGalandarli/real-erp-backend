

using RealERP.Application.DTOs.RequestDto;
using System.Runtime.CompilerServices;

namespace RealERP.Application.Abstraction.Service
{
    public interface IProductService
    {
        public Task<bool> AddProductAsync(ProductRequestDto productRequestDto);
    }
}
