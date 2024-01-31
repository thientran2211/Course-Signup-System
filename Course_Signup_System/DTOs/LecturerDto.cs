using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.DTOs
{
    public class LecturerDto
    {
        public string? TaxCode { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public string? Sex { get; set; }
        [EmailAddress]
        [ValidationEmail]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? MainSubject { get; set; }
        public string? ConcurrentSubject { get; set; }
        public int RoleId { get; set; }
    }
}
