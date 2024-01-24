using System.Text.Json.Serialization;

namespace Course_Signup_System.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        [JsonIgnore]
        public ICollection<User>? Users { get; set; }
    }
}