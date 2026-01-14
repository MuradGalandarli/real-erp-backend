namespace RealERP.Application.Abstraction.Features.Query.Employee.GetByIdEmployee
{
    public class GetByIdEmployeeQueryResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public string? UserId { get; set; }
        public int? CompanyId { get; set; }
    }
}