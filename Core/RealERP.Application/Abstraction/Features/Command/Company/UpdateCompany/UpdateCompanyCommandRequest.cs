using MediatR;
using RealERP.Application.DTOs;

namespace RealERP.Application.Abstraction.Features.Command.Company.UpdateCompany
{
    public class UpdateCompanyCommandRequest:IRequest<UpdateCompanyCommandResponse>
    {
        public int Id { get; set; }
        public CompanyDto Company { get; set; }
    }
}