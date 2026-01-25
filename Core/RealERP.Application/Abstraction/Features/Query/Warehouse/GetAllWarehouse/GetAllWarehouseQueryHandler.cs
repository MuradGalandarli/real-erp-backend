

using MediatR;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Query.Warehouse.GetAllWarehouse
{
    public class GetAllWarehouseQueryHandler : IRequestHandler<GetAllWarehouseQueryRequest, List<GetAllWarehouseQueryResponse>>
    {
        private readonly IWarehouseService _warehouseService;

        public GetAllWarehouseQueryHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<List<GetAllWarehouseQueryResponse>> Handle(GetAllWarehouseQueryRequest request, CancellationToken cancellationToken)
        {
            List<WarehouseDto> warehouseResponseDtos =  _warehouseService.GetAllWarehouse(request.Page, request.Size);

            return warehouseResponseDtos.Select(w => new GetAllWarehouseQueryResponse()
            {
                Description = w.Description,
                Id = w.Id,
                Location = w.Location,
                Name = w.Name,
                CompanyId = w.CompanyId,
            }).ToList();

        } 
    }
}
