namespace RealERP.Application.Abstraction.Features.Command.Login
{
    public class LoginCommandResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}