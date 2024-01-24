using Course_Signup_System.DTOs;

namespace Course_Signup_System.Responses
{
    public class LoginResponse : BaseResponse
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
