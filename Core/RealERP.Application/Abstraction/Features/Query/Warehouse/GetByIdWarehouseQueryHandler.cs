
using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs.ResponseDto;

namespace RealERP.Application.Abstraction.Features.Query.Warehouse
{
    public class GetByIdWarehouseQueryHandler : IRequestHandler<GetByIdWarehouseQueryRequest, GetByIdWarehouseQueryResponse>
    {
        private readonly IWarehouseService _warehouseService;

        public GetByIdWarehouseQueryHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<GetByIdWarehouseQueryResponse> Handle(GetByIdWarehouseQueryRequest request, CancellationToken cancellationToken)
        {
           WarehouseResponseDto warehouseResponseDto = await _warehouseService.GetByIdWarehouseAsync(request.Id);
            return new()
            {
                Id = warehouseResponseDto.Id,
                Description = warehouseResponseDto.Description,
                Location = warehouseResponseDto.Location,
                Name = warehouseResponseDto.Name
            };
        }
    }
}
