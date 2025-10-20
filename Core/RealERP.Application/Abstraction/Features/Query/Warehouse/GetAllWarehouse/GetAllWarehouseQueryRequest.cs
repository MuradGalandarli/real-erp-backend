using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Warehouse.GetAllWarehouse
{
    public class GetAllWarehouseQueryRequest:IRequest<List<GetAllWarehouseQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}