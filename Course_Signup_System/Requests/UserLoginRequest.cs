using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Requests
{
    public class UserLoginRequest
    {
        [Required, EmailAddress]
        [ValidationEmail]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
