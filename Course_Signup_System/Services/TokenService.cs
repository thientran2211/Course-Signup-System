using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Course_Signup_System.Services
{
    public class TokenService : ITokenService
    {
        private readonly CourseSignupContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenService(CourseSignupContext dbContext, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }
        public string CreateToken(User user)
        {

            var roleName = _dbContext.Roles
                .Where(r => r.RoleId == user.RoleId)
                .Select(r => r.RoleName)
                .FirstOrDefault();

            roleName ??= "Admin";

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, roleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public RefreshTokenDto GenerateRefreshToken(User user)
        {
            var roleName = _dbContext.Roles
                .Where(r => r.RoleId == user.RoleId)
                .Select(r => r.RoleName)
                .FirstOrDefault();

            roleName ??= "Admin";

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, roleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var refreshToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(7), // Set the expiration time for the refresh token
                signingCredentials: creds);

            var refreshTokenDto = new RefreshTokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(refreshToken),
                Created = DateTime.Now,
                Expires = refreshToken.ValidTo
            };

            return refreshTokenDto;
        }

        public void SetRefreshTokenInCookie(RefreshTokenDto refreshTokenDto)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, // Prevents JavaScript access to the cookie
                Secure = true,   // Send cookie only over HTTPS if available
                Expires = refreshTokenDto.Expires
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshTokenDto.Token, cookieOptions);
        }
       
    }
}
