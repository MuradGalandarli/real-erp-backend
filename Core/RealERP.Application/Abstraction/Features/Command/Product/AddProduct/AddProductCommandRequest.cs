using MediatR;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices;

namespace RealERP.Application.Abstraction.Features.Command.Product.AddProduct
{
    public class AddProductCommandRequest : IRequest<AddProductCommandResponse>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}