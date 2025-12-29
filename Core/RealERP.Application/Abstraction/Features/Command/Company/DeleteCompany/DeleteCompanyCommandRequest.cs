using MediatR;

namespace RealERP.Application.Abstraction.Features.Command.Company.DeleteCompany
{
    public class DeleteCompanyCommandRequest:IRequest<DeleteCompanyCommandResponse>
    {
        public int Id { get; set; }
    }
}