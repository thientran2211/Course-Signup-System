using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Course_Signup_System.Requests;
using Course_Signup_System.Responses;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Course_Signup_System.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly CourseSignupContext _dbContext;
        private readonly ITokenService _tokenService;

        public AuthenticationService(CourseSignupContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Login(UserLoginRequest request)
        {
            var user = await _dbContext.Users!.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                throw new BadHttpRequestException("User not found!");
            }

            else if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new BadHttpRequestException("Password is incorrect!");
            }
            else
            {
                var userToken = _tokenService.CreateToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();
                await _tokenService.SetRefreshToken(refreshToken);

                int roleId = user.RoleId; // Directly get the RoleId from the user object

                user.RefreshToken = refreshToken.Token;
                user.TokenCreated = refreshToken.Created;
                user.TokenExpires = refreshToken.Expires;
                user.RoleId = roleId;

                await _dbContext.SaveChangesAsync();

                return new LoginResponse 
                {
                    Email = request.Email,
                    Token = userToken,
                    RefreshToken = refreshToken.Token
                };
            }
        }

        public async Task<User> Register(UserRegisterRequest request)
        {
            if (_dbContext.Users.Any(u => u.Email == request.Email))
            {
                throw new BadHttpRequestException("User already exists.");
            }

            CreatePasswordHash(request.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt);

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleId = request.RoleId
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
       
        public async Task<ForgotPasswordResponse> ForgotPassword(string email, ResetPasswordRequest request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new BadHttpRequestException("User not found!");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _dbContext.SaveChangesAsync();

            return new ForgotPasswordResponse { Email = email, PasswordHash = passwordHash, PasswordSalt = passwordSalt };
        }
        
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public async Task<LoginResponse> Logout(string email)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new Exception("User not found!");
            }

            return new LoginResponse
            {
                Email = null,
                Token = null,
                RefreshToken = null,
            };
        }
    }
}
