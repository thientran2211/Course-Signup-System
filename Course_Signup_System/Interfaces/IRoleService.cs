using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetRolesAsync();
        Task<Role> GetRoleAsync(int id);
        Task<Role> AddRoleAsync(RoleDto roleDto);
        Task<Role> UpdateRoleAsync(int id, RoleDto role);
        Task DeleteRoleAsync(int id);
    }
}
