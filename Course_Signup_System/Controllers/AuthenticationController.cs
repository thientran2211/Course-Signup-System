using Course_Signup_System.Data;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Course_Signup_System.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;
        private readonly CourseSignupContext _context;

        public AuthenticationController(IAuthenticationService authenticationService, ITokenService tokenService, CourseSignupContext context)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
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
            if (user == null)
            {
                return Unauthorized("User not found!");
            }
            return Ok(user);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email, ResetPasswordRequest request)
        {
            var user = await _authenticationService.ForgotPassword(email, request);

            return Ok(user);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(string email)
        {
            var user = await _authenticationService.Logout(email);
            return Ok(user);
        }
    }
}
