using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService) 
        {
            _studentService = studentService;
        }

        [Authorize(Roles = "Admin, Lecturer")]
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(students);
        }

        [Authorize(Roles = "Admin, Lecturer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentService.GetStudentAsync(id);
            return Ok(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDto dto)
        {
            var student = await _studentService.CreateStudentAsync(dto);
            return Ok(student);
        }

        [Authorize(Roles = "Admin, Lecturer")]
        [HttpPost("upload-image/{id}")]
        public async Task<IActionResult> UploadStudentImage(int id, IFormFile file)
        {
            var studentImage = await _studentService.UploadStudentImageAsync(id, file);
            return Ok(studentImage);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDto dto)
        {
            var student = await _studentService.UpdateStudentAsync(id, dto);
            return Ok(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return Ok("Delete student succeeded!");
        }
    }
}
