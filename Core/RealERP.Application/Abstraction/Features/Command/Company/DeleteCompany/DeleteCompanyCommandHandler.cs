

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Company.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommandRequest, DeleteCompanyCommandResponse>
    {
        private readonly ICompanyService _companyService;

        public DeleteCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<DeleteCompanyCommandResponse> Handle(DeleteCompanyCommandRequest request, CancellationToken cancellationToken)
        {
           bool status = await _companyService.DeleteCompany(request.Id);
            return new()
            {
                Status = status,
            };
        }
    }
}
