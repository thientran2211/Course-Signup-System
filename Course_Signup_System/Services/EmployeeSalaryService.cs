using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        private readonly CourseSignupContext _context;

        public EmployeeSalaryService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<EmployeeSalary> CreateEmployeeSalaryAsync(EmployeeSalaryDto dto)
        {
            var mClass = await _context.Classes.FindAsync(dto.ClassId)
                ?? throw new Exception($"Class doesn't exist!");
            int tuitionFee = mClass.Fee;
            int numberOfStudent = mClass.NumberOfStudent;
            int salaryPercent = dto.SalaryPercent;
            int allowance = dto.Allowance;
            decimal totalSalary = ((tuitionFee + numberOfStudent) * salaryPercent /100) + allowance;

            var employeeSalary = new EmployeeSalary 
            { 
                SalaryPercent = dto.SalaryPercent,
                Allowance = dto.Allowance,
                TotalSalary = totalSalary,
                ClassId = dto.ClassId,
                LecturerId = dto.LecturerId
            };

            _context.EmployeeSalarys.Add(employeeSalary);
            await _context.SaveChangesAsync();
            return employeeSalary;
        }

        public async Task DeleteEmployeeSalaryAsync(int id)
        {
            var employeeSalary = await GetEmployeeSalaryAsync(id);
            _context.EmployeeSalarys.Remove(employeeSalary);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeSalary>> GetEmployeeSalariesAsync()
        {
            var salaries = await _context.EmployeeSalarys.ToListAsync()
                ?? throw new Exception("There is no employee salaries data");
            return salaries;
        }

        public async Task<EmployeeSalary> GetEmployeeSalaryAsync(int id)
        {
            var salary = await _context.EmployeeSalarys.FindAsync(id)
                ?? throw new Exception($"employee salary of {id} doesn't exist!");
            return salary;
        }

        public async Task<EmployeeSalary> UpdateEmployeeSalaryAsync(int id, EmployeeSalaryDto dto)
        {
            var employeeSalary = await GetEmployeeSalaryAsync(id);

            var mClass = await _context.Classes.FindAsync(dto.ClassId)
                ?? throw new Exception($"Class doesn't exist!");
            int tuitionFee = mClass.Fee;
            int numberOfStudent = mClass.NumberOfStudent;
            int salaryPercent = dto.SalaryPercent;
            int allowance = dto.Allowance;
            decimal totalSalary = ((tuitionFee + numberOfStudent) * salaryPercent / 100) + allowance;

            employeeSalary.SalaryPercent = dto.SalaryPercent;
            employeeSalary.Allowance = dto.Allowance;
            employeeSalary.TotalSalary = totalSalary;
            employeeSalary.ClassId = dto.ClassId;
            employeeSalary.LecturerId = dto.LecturerId;

            _context.EmployeeSalarys.Update(employeeSalary);
            await _context.SaveChangesAsync();
            return employeeSalary;
        }
    }
}
