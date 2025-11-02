using MediatR;

namespace RealERP.Application.Abstraction.Features.Query.Departament.GetAllDepartment
{
    public class GetAllDepartmentQueryRequest:IRequest<List<GetAllDepartmentQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}