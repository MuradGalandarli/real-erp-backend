using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.AuthorizationEndpoint.GetRolesToEndpoints
{
    public class GetRolesToEndpointQueryRequest:IRequest<GetRolesToEndpointQueryResponse>
    {
        public string Code { get; set; }
        public string Menu { get; set; }
    }
}