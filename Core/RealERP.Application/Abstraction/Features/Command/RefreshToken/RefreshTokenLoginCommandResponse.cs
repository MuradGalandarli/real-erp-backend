using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.RefreshToken
{
    public class RefreshTokenLoginCommandResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}