
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Service
{
    public interface IUserService
    {
        public Task<Response> CreateAsync(RegisterDto register);
    }
}
