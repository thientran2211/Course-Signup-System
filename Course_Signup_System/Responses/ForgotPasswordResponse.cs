namespace Course_Signup_System.Responses
{
    public class ForgotPasswordResponse : BaseResponse
    {
        public string? Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }
}
