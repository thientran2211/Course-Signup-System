using Course_Signup_System.Interfaces;
using Course_Signup_System.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _revenueService;

        public RevenueController(IRevenueService revenueService) 
        {
            _revenueService = revenueService;
        }

        [HttpGet("student-have-paid-tuition")]
        public async Task<ActionResult<GetStudentsHavePaidResponse>> GetStudentsHavePaid()
        {
            var studentRevenue = await _revenueService.GetStudentsHavePaidAsync();
            return Ok(studentRevenue);
        }

        [HttpGet("lecturer-salary")]
        public async Task<ActionResult<GetLecturersSalaryResponse>> GetLecturersSalary()
        {
            var lecturerSalary = await _revenueService.GetLecturersSalaryAsync();
            return Ok(lecturerSalary);
        }
    }
}
