using RealERP.Application.DTOs;


namespace RealERP.Application.Abstraction.Service
{
    public interface ICompanyService
    {
        public Task<bool>AddCompany(CompanyDto company);
        public Task<bool>UpdateCompany(CompanyDto company,int id);
    }
}
