using Course_Signup_System.Authentication;
using Course_Signup_System.Models;
using Course_Signup_System.Requests;
using Course_Signup_System.Responses;

namespace Course_Signup_System.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<User> Register(UserRegisterRequest request);
        public Task<LoginResponse> Login(UserLoginRequest request);
        public Task<ForgotPasswordResponse> ForgotPassword(string email, ResetPasswordRequest request);
    }
}
