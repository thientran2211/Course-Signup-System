using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService) 
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            var subjects = await _subjectService.GetSubjectsAsync();
            return Ok(subjects);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(SubjectDto dto)
        {
            var subject = await _subjectService.CreateSubjectAsync(dto);
            return Ok(subject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, SubjectDto dto)
        {
            var subject = await _subjectService.UpdateSubjectAsync(id, dto);
            return Ok(subject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            await _subjectService.DeleteSubjectAsync(id);
            return Ok("Delete subject succeeded!");
        }
    }
}
