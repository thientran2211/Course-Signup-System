namespace Course_Signup_System.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public User? User { get; set; }
    }
}
