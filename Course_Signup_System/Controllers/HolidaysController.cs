using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidayService _holidayService;
        public HolidaysController(IHolidayService holidayService) 
        {
            _holidayService = holidayService;
        }

        [Authorize(Roles = "Admin, Lecturer")]
        [HttpGet]
        public async Task<IActionResult> GetHolidays()
        {
            var holidays = await _holidayService.GetHolidaysAsync();
            return Ok(holidays);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddNewHoliday(HolidaysDto dto)
        {
            var holiday = await _holidayService.AddNewHolidayAsync(dto);
            return Ok(holiday);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHoliday(Guid id, HolidaysDto dto)
        {
            var holiday = await _holidayService.UpdateHolidayAsync(id, dto);
            return Ok(holiday);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveHoliday(Guid id)
        {
            await _holidayService.RemoveHolidayAsync(id);
            return Ok("Removed holiday succeeded!");
        }
    }
}
