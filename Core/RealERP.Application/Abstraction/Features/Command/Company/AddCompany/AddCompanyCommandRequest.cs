using MediatR;
using RealERP.Application.DTOs;
using RealERP.Domain.Enum;

namespace RealERP.Application.Abstraction.Features.Command.Company.AddCompany
{
    public class AddCompanyCommandRequest:IRequest<AddCompanyCommandResponse>
    {
        public CompanyDto companyDto { get; set; } = null!;
       
    }
}