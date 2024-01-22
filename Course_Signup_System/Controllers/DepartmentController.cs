using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService) 
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await departmentService.GetDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await departmentService.GetDepartmentById(id);
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(DepartmentDto departmentDto)
        {
            var department = await departmentService.AddNewDepartment(departmentDto);
            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DepartmentDto departmentDto)
        {
            var department = await departmentService.UpdateDepartment(id, departmentDto);
            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            await departmentService.DeleteDepartment(id);
            return Ok();
        }
    }
}
