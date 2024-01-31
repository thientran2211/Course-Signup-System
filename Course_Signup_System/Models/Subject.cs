using System.Text.Json.Serialization;

namespace Course_Signup_System.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectName { get; set; }

        public int SubjectGroupId { get; set; }
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Department? Department { get; set; }
        [JsonIgnore]
        public SubjectGroup? SubjectGroup { get; set; }

        [JsonIgnore]
        public ICollection<SubjectGradeType>? Grades { get; set; }
    }
}
