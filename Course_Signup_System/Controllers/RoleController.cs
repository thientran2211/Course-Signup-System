using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService) 
        {
            this.roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await roleService.GetRolesAsync();
            if (roles == null)
            {
                return NotFound("There is no data for roles");
            }
            return Ok(roles);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetRole(int id)
        {
            var role = await roleService.GetRoleAsync(id);
            if (role == null)
            {
                return NotFound("Not found role of this id");
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRole(RoleDto roleDto)
        {
            var role = await roleService.AddRoleAsync(roleDto);
            if (role == null)
            {
                return BadRequest("Please enter correct information");
            }
            return Ok(role);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateRole(int id, RoleDto roleDto)
        {
            var role = await roleService.UpdateRoleAsync(id, roleDto);
            if (role == null)
            {
                return BadRequest("Please complete correct information");
            }
            return Ok(role);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await roleService.DeleteRoleAsync(id);
            return Ok("Delete role succeeded!");
        }
    }
}
