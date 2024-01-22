using System.Text.Json.Serialization;

namespace Course_Signup_System.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string? Image { get; set; }

        public int RoleId { get; set; }

        [JsonIgnore]
        public Role? Role { get; set; } 
    }
}
