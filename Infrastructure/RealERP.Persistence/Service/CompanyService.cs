using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Abstraction.Service.UnitOfWork;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
using RealERP.Domain.Entities;

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

        public async Task<bool> DeleteCompany(int id)
        {
           Company companies = await _unitOfWork.readCompanyRepository.GetByIdAsync(id);
            if (companies == null)
                throw new NotFoundException($"There are not this {id} company");
            _unitOfWork.writeCompanyRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
                
        }

        public async Task<bool> UpdateCompany(CompanyDto company,int id)
        {
            try
            {
                _unitOfWork.writeCompanyRepository.Update(new()
                {
                    Id = id,
                    Address = company.Address,
                    City = company.City,
                    Name = company.Name,
                    Email = company.Email,
                    Phone = company.Phone,
                    Country = company.Country,

                });
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message.ToString());
                return false;
            }
            return true;
            
        }
    }
}
