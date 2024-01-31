using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Lecturer")]
    public class SubjectGradeTypeController : ControllerBase
    {
        private readonly ISubjectGradeTypeService _subjectGradeType;

        public SubjectGradeTypeController(ISubjectGradeTypeService subjectGradeType) 
        {
            _subjectGradeType = subjectGradeType;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjectGradeTypes()
        {
            var subjectGradeTypes = await _subjectGradeType.GetSubjectGradeTypesAsync();
            return Ok(subjectGradeTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectGradeType(int id)
        {
            var subjectGradeType = await _subjectGradeType.GetSubjectGradeTypeAsync(id);
            return Ok(subjectGradeType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubjectGradeType(SubjectGradeTypeDto dto)
        {
            var subjectGradeType = await _subjectGradeType.CreateSubjectGradeTypeAsync(dto);
            return Ok(subjectGradeType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubjectGradeType(int id,  SubjectGradeTypeDto dto)
        {
            var subjectGradeType = await _subjectGradeType.UpdateSubjectGradeTypeAsync(id, dto);
            return Ok(subjectGradeType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectGradeType(int id)
        {
            await _subjectGradeType.DeleteSubjectGradeTypeAsync(id);
            return Ok("Delete subject grade type succeeded!");
        }
    }
}
