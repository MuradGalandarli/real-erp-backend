using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Warehouse.WarehouseAdd
{
    public class AddWarehouseCommandRequest:IRequest<AddWarehouseCommandResponse>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
        public int CompanyId { get; set; }
    }
}