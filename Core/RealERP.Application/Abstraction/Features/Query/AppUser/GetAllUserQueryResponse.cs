namespace RealERP.Application.Abstraction.Features.Query.AppUser
{
    public class GetAllUserQueryResponse
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? CompanyId { get; set; }
    }
}