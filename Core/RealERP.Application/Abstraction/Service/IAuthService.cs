using RealERP.Application.DTOs;
using RealERP.Domain.Entities.User;


namespace RealERP.Application.Abstraction.Service
{
    public interface IAuthService
    {
        public Task<TokenDto> LoginAsync(LoginDto login,int lifeTIme, int refreshTokenLifeTime);
        public Task<TokenDto> UpdateRefreshToken(string refreshToken, int accessTokenDate, int refreshTokenLifeTime);
    }
}
