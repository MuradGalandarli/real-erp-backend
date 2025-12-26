

using MediatR;
using RealERP.Application.Abstraction.Service;

namespace RealERP.Application.Abstraction.Features.Command.Company.AddCompany
{
    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommandRequest, AddCompanyCommandResponse>
    {
        private readonly ICompanyService _companyService;

        public AddCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<AddCompanyCommandResponse> Handle(AddCompanyCommandRequest request, CancellationToken cancellationToken)
        {
           bool status = await _companyService.AddCompany(request.companyDto);
            return new()
            {
                Status = status,
            };
        }
    }
}
