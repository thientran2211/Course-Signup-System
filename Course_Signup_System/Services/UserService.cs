using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Course_Signup_System.Services
{
    public class UserService : IUserService
    {
        private readonly CourseSignupContext _context;

        public UserService(CourseSignupContext context) 
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return users;
            }
            catch
            {
                throw new Exception("There is no user data");
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                return user ?? throw new NotImplementedException();
            }
            catch
            {
                throw new Exception("Not found user for this id");
            }
        }

        public async Task<User> AddUserAsync(UserDto userDto)
        {
            try
            {
                CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                 
                var user = new User
                {
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    RoleId = userDto.RoleId
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch
            {
                throw new NotImplementedException("Please complete correct information to add new user");
            }
            
        }

        public async Task<User> UpdateUserAsync(int id, UserDto userDto)
        {
            try
            {
                var user = await _context.Users.FindAsync(id) 
                    ?? throw new Exception("Doesn't exist user for this id");

                CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.UserName = userDto.UserName;
                user.Email = userDto.Email;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.RoleId = userDto.RoleId;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch { throw new NotImplementedException(); }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.UserId == id)
                    ?? throw new Exception("Doesn't exist user for this id");
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch { throw new NotImplementedException(); }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
