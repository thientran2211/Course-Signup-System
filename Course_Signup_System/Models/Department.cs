using System.Text.Json.Serialization;

namespace Course_Signup_System.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        [JsonIgnore]
        public ICollection<Class>? Classes { get; set; }
    }
}
