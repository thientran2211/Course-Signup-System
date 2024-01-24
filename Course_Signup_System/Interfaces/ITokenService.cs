using Course_Signup_System.DTOs;
using Course_Signup_System.Models;
using System.Security.Claims;

namespace Course_Signup_System.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(User user);
        public Task SetRefreshToken(RefreshTokenDto newRefreshToken);
        public RefreshTokenDto GenerateRefreshToken();
    }
}
