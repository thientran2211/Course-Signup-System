using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturingScheduleController : ControllerBase
    {
        private readonly ILecturingScheduleService _lecturingSchedule;

        public LecturingScheduleController(ILecturingScheduleService lecturingSchedule)
        {
            _lecturingSchedule = lecturingSchedule;
        }

        [Authorize(Roles = "Admin, Lecturer")]
        [HttpGet]
        public async Task<IActionResult> GetLecturingSchedules()
        {
            var lecturingSchedules = await _lecturingSchedule.GetLecturingSchedulesAsync();
            return Ok(lecturingSchedules);
        }

        [Authorize(Roles = "Admin, Lecturer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLecturingSchedule(int id)
        {
            var lecturingSchedule = await _lecturingSchedule.GetLecturingScheduleAsync(id);
            return Ok(lecturingSchedule);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateLecturingSchedule(LecturingScheduleDto dto)
        {
            var lecturingSchedule = await _lecturingSchedule.CreateLecturingScheduleAsync(dto);
            return Ok(lecturingSchedule);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLecturingSchedule(int id, LecturingScheduleDto dto)
        {
            var lecturingSchedule = await _lecturingSchedule.UpdateLecturingScheduleAsync(id, dto);
            return Ok(lecturingSchedule);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturingSchedule(int id)
        {
            await _lecturingSchedule.DeleteLecturingScheduleAsync(id);
            return Ok("delete lecturing schedule succeeded!");
        }
    }
}
