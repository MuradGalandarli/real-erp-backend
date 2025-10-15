using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseAdd
{
    public class AddWarehouseCommandHandler : IRequestHandler<AddWarehouseCommandRequest, AddWarehouseCommandResponse>
    {
        private readonly IWarehouseService _warehouseService;

        public AddWarehouseCommandHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<AddWarehouseCommandResponse> Handle(AddWarehouseCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _warehouseService.AddWarehouseAsync(new()
            {
                Description = request.Description,
                Location = request.Location,
                Name = request.Name,
            });
            return new()
            {
                Status = status,
            };
        }
    }
}
