using System.ComponentModel;

namespace RealERP.Application.DTOs
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken {  get; set; }
    }
}
