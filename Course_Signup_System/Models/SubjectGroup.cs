using System.Text.Json.Serialization;

namespace Course_Signup_System.Models
{
    public class SubjectGroup
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [JsonIgnore]
        public ICollection<Subject>? Subjects { get; set;}
    }
}
