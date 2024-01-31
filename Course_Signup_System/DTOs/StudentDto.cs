using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.DTOs
{
    public class StudentDto
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public string? Sex { get; set; }
        [EmailAddress, ValidationEmail]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? ParentName { get; set; }

        public int CourseId { get; set; }
        public int ClassId { get; set; }
        public int RoleId { get; set; }
    }
}
