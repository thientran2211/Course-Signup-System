using System.Text.Json.Serialization;

namespace Course_Signup_System.Models
{
    public class LecturingSchedule
    {
        public int Id { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set;}
        public string? Classroom { get; set; }
        public string? TeachingDay { get; set; }

        public int SubjectId { get; set; }
        public int LecturerId { get; set; }
        public int ClassId { get; set; }

        [JsonIgnore]
        public Lecturer? Lecturer { get; set; }
        [JsonIgnore]
        public Subject? Subject { get; set; }

        [JsonIgnore]
        public ICollection<Class>? Classes { get; set; }
    }
}
