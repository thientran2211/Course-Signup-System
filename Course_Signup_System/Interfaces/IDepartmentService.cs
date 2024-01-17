using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<Department> AddNewDepartment(DepartmentDto departmentDto);
        Task<Department> UpdateDepartment(int id, DepartmentDto departmentDto);
        Task DeleteDepartment(int id);
    }
}
