using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<User> AddUserAsync(UserDto userDto);
        Task<User> UpdateUserAsync(int id, UserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
