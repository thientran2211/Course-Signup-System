using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly CourseSignupContext _context;

        public DepartmentService(CourseSignupContext context) 
        {
            _context = context;
        }

        public async Task<List<Department>> GetDepartments()
        {
            try
            {
                var departments = await _context.Departments.ToListAsync();
                return departments;
            }
            catch { throw new NotImplementedException("There is no data departments in database."); }
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            try
            {
                var department = await _context.Departments.FindAsync(id)
                    ??throw new Exception("There is no department data of this id");   
                
                return department;
            }
            catch { throw new NotImplementedException(); }
        }

        public async Task<Department> AddNewDepartment(DepartmentDto departmentDto)
        {
            try
            { 
                var department = new Department
                {
                    DepartmentName = departmentDto.DepartmentName
                };
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return department;
            }
            catch { throw new Exception("Please complete correct information to add new department"); }
        }

        public async Task<Department> UpdateDepartment(int id, DepartmentDto departmentDto)
        {
            try
            {
                var department = _context.Departments.Find(id)
                    ??throw new Exception("there is no department data of this id");
                
                department.DepartmentName = departmentDto.DepartmentName;
                _context.Departments.Update(department);
                await _context.SaveChangesAsync();
                return department;
            }
            catch { throw new NotImplementedException(); }
        }

        public async Task DeleteDepartment(int id)
        {
            try
            {
                var department = _context.Departments.Find(id)
                    ?? throw new Exception("there is no department data of this id");
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
            catch { throw new NotImplementedException(); }
        }
    }
}
