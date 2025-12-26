using Microsoft.Extensions.Logging;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Abstraction.Service.UnitOfWork;
using RealERP.Application.DTOs;

namespace RealERP.Persistence.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(IUnitOfWork unitOfWork, ILogger<CompanyService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> AddCompany(CompanyDto company)
        {
            try
            {
                await _unitOfWork.writeCompanyRepository.AddAsync(new()
                {
                    Address = company.Address,
                    City = company.City,
                    Name = company.Name,
                    Email = company.Email,
                    Phone = company.Phone,
                    Country = company.Country,
                });
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return false;
            }
            return true;
        }
    }
}
