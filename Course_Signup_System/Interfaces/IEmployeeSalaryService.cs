using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface IEmployeeSalaryService
    {
        Task<List<EmployeeSalary>> GetEmployeeSalariesAsync();
        Task<EmployeeSalary> GetEmployeeSalaryAsync(int id);
        Task<EmployeeSalary> CreateEmployeeSalaryAsync(EmployeeSalaryDto dto);
        Task<EmployeeSalary> UpdateEmployeeSalaryAsync(int id, EmployeeSalaryDto dto);
        Task DeleteEmployeeSalaryAsync(int id);
    }
}
