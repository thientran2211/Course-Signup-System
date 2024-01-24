using Course_Signup_System.DTOs;
using Course_Signup_System.Models;
using System.Security.Claims;

namespace Course_Signup_System.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(User user);
        public RefreshTokenDto GenerateRefreshToken(User user);
        public void SetRefreshTokenInCookie(RefreshTokenDto refreshTokenDto);
    }
}
