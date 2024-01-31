using System.Text.Json.Serialization;

namespace Course_Signup_System.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }

        [JsonIgnore]
        public ICollection<SubjectGradeType>? Grades { get; set; }
    }
}
