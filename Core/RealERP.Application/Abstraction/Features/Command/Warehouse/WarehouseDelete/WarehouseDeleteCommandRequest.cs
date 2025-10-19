using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseDelete
{
    public class WarehouseDeleteCommandRequest:IRequest<WarehouseDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}