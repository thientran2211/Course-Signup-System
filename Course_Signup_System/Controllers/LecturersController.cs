using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class LecturersController : ControllerBase
    {
        private readonly ILecturerService _lecturerService;

        public LecturersController(ILecturerService lecturerService) 
        {
            _lecturerService = lecturerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLecturers()
        {
            var lecturers = await _lecturerService.GetLecturersAsync();
            return Ok(lecturers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLecturerById(int id)
        {
            var lecturer = await _lecturerService.GetLecturerAsync(id);
            return Ok(lecturer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewLecturer(LecturerDto dto)
        {
            var lecturer = await _lecturerService.CreateLecturerAsync(dto);
            return Ok(lecturer);    
        }

        [HttpPost("upload-image/{id}")]
        public async Task<IActionResult> UploadLecturerImage(int id, IFormFile file)
        {
            var lecturerImage = await _lecturerService.UploadLecturerImageAsync(id, file);
            return Ok(lecturerImage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLecturer(int id, LecturerDto dto)
        {
            var lecturer = await _lecturerService.UpdateLecturerAsync(id, dto);
            return Ok(lecturer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturer(int id)
        {
            await _lecturerService.DeleteLecturerAsync(id);
            return Ok("Delete lecturer succeeded!");
        }
    }
}
