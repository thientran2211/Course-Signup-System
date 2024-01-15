using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class RoleService : IRoleService
    {
        private readonly CourseSignupContext _context;

        public RoleService(CourseSignupContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();
                return roles;
            }
            catch { throw new Exception("There is no role data"); }
        }

        public async Task<Role> GetRoleAsync(int id)
        {
            try
            {
                var role = await _context.Roles.FindAsync(id);
                return role == null ? throw new Exception("Role not found for this id") : role;
            }
            catch { throw new Exception("Role not found"); }
        }

        public async Task<Role> AddRoleAsync(RoleDto roleDto)
        {
            var role = new Role
            {
                RoleName = roleDto.RoleName
            };

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRoleAsync(int id, RoleDto model)
        {
            var existingRole = await _context.Roles.FindAsync(id)
                ?? throw new Exception("Role not found for this id");
            existingRole.RoleName = model.RoleName;
            _context.Roles.Update(existingRole);
            await _context.SaveChangesAsync();
            return existingRole;
        }

        public async Task DeleteRoleAsync(int id)
        {
            var existingRole = _context.Roles.SingleOrDefault(r => r.RoleId == id)
                ?? throw new Exception("Role not found for this id");
            _context.Roles.Remove(existingRole);
            await _context.SaveChangesAsync();
        }

    }
}
