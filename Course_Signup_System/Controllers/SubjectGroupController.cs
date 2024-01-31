using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SubjectGroupController : ControllerBase
    {
        private readonly ISubjectGroupService _subjectGroupService;
        public SubjectGroupController(ISubjectGroupService subjectGroupService) 
        {
            _subjectGroupService = subjectGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjectGroup()
        {
            var subjectGroups = await _subjectGroupService.GetSubjectGroupsAsync();
            return Ok(subjectGroups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectGroupById(int id)
        {
            var subjectGroup = await _subjectGroupService.GetSubjectGroupByIdAsync(id);
            return Ok(subjectGroup);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSubjectGroup(SubjectGroupDto subjectGroupDto)
        {
            var subjectGroup = await _subjectGroupService.AddNewSubjectGroupAsync(subjectGroupDto);
            return Ok(subjectGroup);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubjectGroup(int id, SubjectGroupDto subjectGroupDto)
        {
            var subjectGroup = await _subjectGroupService.UpdateSubjectGroupAsync(id, subjectGroupDto);
            return Ok(subjectGroup);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectGroup (int id)
        {
            await _subjectGroupService.DeleteSubjectGroupAsync(id);
            return Ok("Delete subject group succeeded!");
        }
    }
}
