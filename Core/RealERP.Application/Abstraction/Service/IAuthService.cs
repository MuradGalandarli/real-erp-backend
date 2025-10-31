using RealERP.Application.DTOs;


namespace RealERP.Application.Abstraction.Service
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> LoginAsync(LoginDto login);
    }
}
