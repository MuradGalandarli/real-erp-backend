using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Abstraction.Service.UnitOfWork;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
using RealERP.Domain.Entities;
using RealERP.Domain.Entities.User;


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
                bool exists = await _unitOfWork.readCompanyRepository.Table
      .AnyAsync(x => x.Name == company.Name && !x.IsDeleted);

                if (exists)
                    throw new BadRequestException("Company name already exists");

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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return false;
            }
            return true;
        }
        public async Task<bool> DeleteCompany(int id)
        { 

        Company? companies = await _unitOfWork.readCompanyRepository.Table.
                Include(department=> department.Departments).
                Include(e=>e.Employees).
                Include(p=>p.Products).
                Include(w=>w.Warehouses).
                Include(d=>d.Departments).
                Include(b=>b.Brands).
                Include(c=>c.Categories).
                Include(u=>u.Users).
                FirstOrDefaultAsync(c=>c.Id == id);

            if (companies == null)
                throw new NotFoundException($"There are not this {id} company");

            foreach (AppUser company in companies.Users) {
            company.IsDeleted = true;
            }
            foreach (Department department in companies.Departments)
            {
                department.IsDeleted = true;
            }
            foreach (Employee employee in companies.Employees)
            {
                employee.IsDeleted = true;
            }
            foreach (Product product in companies.Products)
            {
                product.IsDeleted = true;
            }
            foreach (Warehouse warehouse in companies.Warehouses)
            {
               warehouse.IsDeleted = true;
            }
            foreach (Brand brand in companies.Brands)
            {
                brand.IsDeleted = true;
            }
            foreach (Category category in companies.Categories)
            {
                category.IsDeleted = true;
            }
            foreach (AppUser appUser in companies.Users)
            {
                appUser.IsDeleted = true;
            }
            companies.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;

        }

        public async Task<List<CompanyDto>> GetAllCompany(int page, int size)
        {
            List<Company> companies = await _unitOfWork.readCompanyRepository.GetAll().Skip((page - 1) * size).Take(size).ToListAsync();
            return companies.Select(x=> new CompanyDto
            {
                Id = x.Id,
                Address=x.Address,
                City=x.City,    
                Country=x.Country,
                Name=x.Name,
                Phone=x.Phone,
                Email =x.Email,
            }).ToList();
        }

        public async Task<CompanyDto> GetByIdCompany(int id)
        {
            Company company = await _unitOfWork.readCompanyRepository.GetByIdAsync(id);
            if (company == null)
                throw new NotFoundException($"There are not this {id} company");
            return new CompanyDto()
            {
                Address = company.Address,
                City = company.City,
                Name = company.Name,
                Email = company.Email,
                Phone = company.Phone,
                Country = company.Country,
            };
        }

        public async Task<bool> UpdateCompany(CompanyDto company)
        {
            try
            {
                Company data = new()
                {
                    Id = company.Id,
                    Address = company.Address,
                    City = company.City,
                    Name = company.Name,
                    Email = company.Email,
                    Phone = company.Phone,
                    Country = company.Country,
                };

                _unitOfWork.writeCompanyRepository.Update(data);
               
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
