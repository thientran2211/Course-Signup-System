using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TuitionFeeController : ControllerBase
    {
        private readonly ITuitionFeeService _tuitionFeeService;

        public TuitionFeeController(ITuitionFeeService tuitionFeeService) 
        {
            _tuitionFeeService = tuitionFeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTuitionFees()
        {
            var tuitionFees = await _tuitionFeeService.GetTuitionFeesAsync();
            return Ok(tuitionFees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTuitionFee(int id)
        {
            var tuitionFee = await _tuitionFeeService.GetTuitionByIdAsync(id);
            return Ok(tuitionFee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTuitionFee(TuitionFeeDto dto)
        {
            var tuitionFee = await _tuitionFeeService.CreateTuitionAsync(dto);
            return Ok(tuitionFee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTuitionFee(int id,  TuitionFeeDto dto)
        {
            var tuitionFee = await _tuitionFeeService.UpdateTuitionAsync(id, dto);
            return Ok(tuitionFee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTuitionFee(int id)
        {
            await _tuitionFeeService.DeleteTuitionAsync(id);
            return Ok("delete tuition fee succeeded!");
        }
    }
}
