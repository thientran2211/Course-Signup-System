using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Requests
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword {  get; set; } = string.Empty;
    }
}
