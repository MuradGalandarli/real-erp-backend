using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Departament.GetByIdDepartment
{
    public class GetByIdDepartmentQueryRequest:IRequest<GetByIdDepartmentQueryResponse>
    {
        public int Id { get; set; }
    }
}