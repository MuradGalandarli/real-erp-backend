

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseDelete
{
    public class WarehouseDeleteCommandHandler : IRequestHandler<WarehouseDeleteCommandRequest, WarehouseDeleteCommandResponse>
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseDeleteCommandHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<WarehouseDeleteCommandResponse> Handle(WarehouseDeleteCommandRequest request, CancellationToken cancellationToken)
        {
           bool status = await _warehouseService.DeleteWarehouseAsync(request.Id);
            return new()
            {
                Status = status
            };
        }
    }
}
