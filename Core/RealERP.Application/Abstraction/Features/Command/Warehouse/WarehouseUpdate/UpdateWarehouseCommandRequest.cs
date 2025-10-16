using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseUpdate
{
    public class UpdateWarehouseCommandRequest:IRequest<UpdateWarehouseCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
    }
}