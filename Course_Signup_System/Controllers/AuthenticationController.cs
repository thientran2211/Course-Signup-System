using Course_Signup_System.Interfaces;
using Course_Signup_System.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            var user = await _authenticationService.Register(request);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var user = await _authenticationService.Login(request);
            if (user == null)
            {
                return Unauthorized("User not found!");
            }
            return Ok(user);
        }
       
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email, ResetPasswordRequest request)
        {
            var user = await _authenticationService.ForgotPassword(email, request);

            return Ok(user);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(string email)
        {
            var user = await _authenticationService.Logout(email);
            return Ok(user);
        }
    }
}
