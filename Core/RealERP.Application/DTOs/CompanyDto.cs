using RealERP.Domain.Enum;

namespace RealERP.Application.DTOs
{
    public class CompanyDto
    {
        public  int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
    }
}
