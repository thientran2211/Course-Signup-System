using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) 
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await userService.GetUserAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserDto userDto)
        {
            var user = await userService.AddUserAsync(userDto);
            return Ok(user);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
        {
            var user = await userService.UpdateUserAsync(id, userDto);
            return Ok(user);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await userService.DeleteUserAsync(id);
            return Ok("Delete user succeeded!");
        }
    }
}
