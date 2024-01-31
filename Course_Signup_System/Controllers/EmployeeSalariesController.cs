using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EmployeeSalariesController : ControllerBase
    {
        private readonly IEmployeeSalaryService _employeeSalary;

        public EmployeeSalariesController(IEmployeeSalaryService employeeSalary) 
        {
            _employeeSalary = employeeSalary;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeSalaries()
        {
            var employeeSalaries = await _employeeSalary.GetEmployeeSalariesAsync();
            return Ok(employeeSalaries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeSalary(int id)
        {
            var employeeSalary = await _employeeSalary.GetEmployeeSalaryAsync(id);
            return Ok(employeeSalary);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeSalary(EmployeeSalaryDto dto)
        {
            var employeeSalary = await _employeeSalary.CreateEmployeeSalaryAsync(dto);
            return Ok(employeeSalary);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeSalary(int id, EmployeeSalaryDto dto)
        {
            var employeeSalary = await _employeeSalary.UpdateEmployeeSalaryAsync(id, dto);
            return Ok(employeeSalary);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeSalary(int id)
        {
            await _employeeSalary.DeleteEmployeeSalaryAsync(id);
            return Ok("Delete employee salary succeeded!");
        }
    }
}
