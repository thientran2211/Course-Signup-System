using System.Text.Json.Serialization;

namespace Course_Signup_System.Models
{
    public class StudentSchedule
    {
        public int Id { get; set; }
        public string? Class { get; set; }
        public string? Time { get; set; }
        public string? Day { get; set; }
        public string? Period { get; set; }

        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }
    }
}
