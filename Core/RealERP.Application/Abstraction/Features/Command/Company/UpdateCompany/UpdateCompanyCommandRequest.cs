using MediatR;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Command.Company.UpdateCompany
{
    public class UpdateCompanyCommandRequest:IRequest<UpdateCompanyCommandResponse>
    {
        public CompanyDto Company { get; set; }
    }
}