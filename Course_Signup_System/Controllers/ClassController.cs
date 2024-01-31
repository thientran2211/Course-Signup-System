using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Lecturer")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService) 
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClasses()
        {
            var classes = await _classService.GetClassesAsync();
            return Ok(classes);
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            var mClass = await _classService.GetClassAsync(id);
            return Ok(mClass);
        }

        [HttpGet("class-of-student/{id}")]
        public async Task<IActionResult> GetStudentsInClass(int id)
        {
            var studentInClass = await _classService.GetStudentsInClassAsync(id);
            return Ok(studentInClass);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewClass(ClassDto dto)
        {
            var newClass = await _classService.CreateClassAsync(dto);
            return Ok(newClass);
        }

        [HttpPost("upload-image/{id}")]
        public async Task<IActionResult> UploadClassImage(int id, IFormFile file)
        {
            var imageOfClass = await _classService.UploadClassImageAsync(id, file);
            return Ok(imageOfClass);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, ClassDto dto)
        {
            var classUpdate = await _classService.UpdateClassAsync(id, dto);
            return Ok(classUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            await _classService.DeleteClassAsync(id);
            return Ok("Delete class succeeded!");
        }
    }
}
