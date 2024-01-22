namespace Course_Signup_System.Responses
{
    public class LoginResponse : BaseResponse
    {
        public string? Email { get; set; }
        public string? RoleName { get; set; }
        public string? Token { get; set; }
    }
}
