using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Warehouse
{
    public class GetByIdWarehouseQueryRequest:IRequest<GetByIdWarehouseQueryResponse>
    {
        public int Id { get; set; }
       
    }
}