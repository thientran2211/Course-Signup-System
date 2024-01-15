using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.DTOs
{
    public class UserDto
    {
        public string? UserName { get; set; }
        [Required, EmailAddress]
        [ValidationEmail]
        public string? Email { get; set; }
        public string? Password { get; set; }

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
