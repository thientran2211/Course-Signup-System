using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) 
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetDepartmentById(id);
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(DepartmentDto departmentDto)
        {
            var department = await _departmentService.AddNewDepartment(departmentDto);
            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DepartmentDto departmentDto)
        {
            var department = await _departmentService.UpdateDepartment(id, departmentDto);
            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            await _departmentService.DeleteDepartment(id);
            return Ok();
        }
    }
}
