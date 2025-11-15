using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.RefreshToken
{
    public class RefreshTokenLoginCommandRequest:IRequest<RefreshTokenLoginCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}