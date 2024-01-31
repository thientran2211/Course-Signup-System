using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Course_Signup_System.Models
{
    public class Lecturer
    {
        public int LecturerId { get; set; }
        public string? TaxCode { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set;}
        public DateTime? DateOfBirth { get; set; }
        public string? Sex { get; set; }
        public string? Email { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? MainSubject { get; set; }
        public string? ConcurrentSubject { get; set; }
        public string? Image {  get; set; }
        public int RoleId { get; set; }

        [JsonIgnore]
        public Role? Role { get; set; }

        [JsonIgnore]
        public ICollection<LecturingSchedule>? LecturingSchedules { get; set; }
    }
}
