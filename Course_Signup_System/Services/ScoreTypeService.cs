using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class ScoreTypeService : IScoreTypeService
    {
        private readonly CourseSignupContext _context;

        public ScoreTypeService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<ScoreType> CreateScoreTypeAsync(ScoreTypeDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var scoreType = new ScoreType
            {
                Name = dto.ScoreTypeName,
                ScoreScale = dto.ScoreScale
            };
            _context.ScoreTypes.Add(scoreType);
            await _context.SaveChangesAsync();
            return scoreType;
        }

        public async Task DeleteScoreTypeAsync(int id)
        {
            var scoreType = await _context.ScoreTypes.SingleOrDefaultAsync(s => s.Id == id)
                ?? throw new Exception($"{id} of score type does not exist!");

            _context.ScoreTypes.Remove(scoreType);
            await _context.SaveChangesAsync();
        }

        public async Task<ScoreType> GetScoreTypeAsync(int id)
        {
            var scoreType = await _context.ScoreTypes.FindAsync(id)
                ?? throw new Exception($"{id} of score type does not exist!");
            return scoreType;

        }

        public async Task<List<ScoreType>> GetScoreTypesAsync()
        {
            var scoreTypes = await _context.ScoreTypes.ToListAsync()
                ?? throw new Exception("There is no data of score type!");
            return scoreTypes;
        }

        public async Task<ScoreType> UpdateScoreTypeAsync(int id, ScoreTypeDto dto)
        {
            var existingScoreType = await _context.ScoreTypes.FindAsync(id)
                ?? throw new Exception($"{id} of score type does not exist!");

            existingScoreType.Name = dto.ScoreTypeName;
            existingScoreType.ScoreScale = dto.ScoreScale;
            _context.ScoreTypes.Update(existingScoreType);
            await _context.SaveChangesAsync();
            return existingScoreType;
        }
    }
}
