using System.Text.Json.Serialization;

namespace Course_Signup_System.Models
{
    public class ScoreType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ScoreScale { get; set; }

        [JsonIgnore]
        public ICollection<SubjectGradeType>? SubjectGrades { get; set;}
    }
}
