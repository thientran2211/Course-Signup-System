using Course_Signup_System.Authentication;
using Course_Signup_System.Data;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Course_Signup_System.Requests;
using Course_Signup_System.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly CourseSignupContext _context;

        public AuthenticationController(IAuthenticationService authenticationService, CourseSignupContext context)
        {
            _authenticationService = authenticationService;
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            var user = await _authenticationService.Register(request);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var user = await _authenticationService.Login(request);
            return Ok(user);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email, ResetPasswordRequest request)
        {           
            var user = await _authenticationService.ForgotPassword(email, request);

            return Ok(user);                                 
        }
    }
}
