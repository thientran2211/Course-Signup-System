using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_Signup_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Lecturer")]
    public class ScoreTypeController : ControllerBase
    {
        private readonly IScoreTypeService _scoreTypeService;

        public ScoreTypeController(IScoreTypeService scoreTypeService) 
        {
            _scoreTypeService = scoreTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetScoreTypes()
        {
            var scoreType = await _scoreTypeService.GetScoreTypesAsync();
            return Ok(scoreType);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScoreTypeById(int id)
        {
            var scoreType = await _scoreTypeService.GetScoreTypeAsync(id);
            return Ok(scoreType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateScoreType(ScoreTypeDto dto)
        {
            var scoreType = await _scoreTypeService.CreateScoreTypeAsync(dto);
            return Ok(scoreType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScoreType(int id, ScoreTypeDto dto)
        {
            var scoreType = await _scoreTypeService.UpdateScoreTypeAsync(id, dto);
            return Ok(scoreType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScoreType(int id)
        {
            await _scoreTypeService.DeleteScoreTypeAsync(id);
            return Ok("Delete score type succeeded!");
        }
    }
}
