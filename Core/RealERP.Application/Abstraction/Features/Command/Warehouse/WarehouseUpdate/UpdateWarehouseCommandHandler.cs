
using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseUpdate
{
    public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommandRequest, UpdateWarehouseCommandResponse>
    {
        private readonly IWarehouseService _warehouseService;

        public UpdateWarehouseCommandHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<UpdateWarehouseCommandResponse> Handle(UpdateWarehouseCommandRequest request, CancellationToken cancellationToken)
        {
            bool ststus = await _warehouseService.UpdateWarehouseAsync(new()
            {
                Id = request.Id,
                Description = request.Description,
                Location = request.Location,
                Name = request.Name,

            });
            return new()
            {
                Staurs = ststus,
            };
        }
    }
}
