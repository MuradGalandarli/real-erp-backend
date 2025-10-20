

using RealERP.Domain.Entities;

namespace RealERP.Application.Abstraction.Service
{
    public interface IBrandService
    {
        public Task<bool> AddBrnad(Brand brand);
    }
}
