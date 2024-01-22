using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Requests
{
    public class UserRegisterRequest
    {
        public string UserName { get; set; } = string.Empty;
        [Required, EmailAddress]
        [ValidationEmail]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword {  get; set; } = string.Empty;
        [Required]
        public int RoleId { get; set; }
    }

    public class ValidationEmail : ValidationAttribute
    {
        private const string Required = "gmail.com";

        public override bool IsValid(object? value)
        {
            if (value == null || value is not string)
            {
                return true;
            }

            string email = (string)value;
            if (email.EndsWith($"@{Required}", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            ErrorMessage = "Email must belong to domain @gmail.com";
            return false;
        }
    }
}
